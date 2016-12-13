using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Net.Sockets;
using System.Threading;

namespace GalaxyTruckerClient
{
    public partial class MainWindow : Form
    {
        SpaceshipSegment DraggingSegment { get; set; }
        SpaceshipSegment CurrentSegment { get; set; }
        SpaceshipSegment[] StoreSegments { get; set; }
        Spaceship Ship { get; set; }
        ServerConnection connection { get; set; }
        List<SpaceshipSegment> openedSegments { get; set; }
        bool isReady = false;
        int timeLeft = 120;

        public MainWindow()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            queuePictureBox.MouseDown += queuePictureBox_MouseDown;

            storePictureBox1.DragEnter += storePictureBox_DragEnter;
            storePictureBox2.DragEnter += storePictureBox_DragEnter;
            storePictureBox1.DragDrop += storePictureBox_DragDrop;
            storePictureBox2.DragDrop += storePictureBox_DragDrop;
            storePictureBox1.AllowDrop = true;
            storePictureBox2.AllowDrop = true;
            storePictureBox1.MouseDown += storePictureBox_MouseDown;
            storePictureBox2.MouseDown += storePictureBox_MouseDown;

            openPanel.DragEnter += openPanel_DragEnter;
            openPanel.DragDrop += openPanel_DragDrop;

            cardsButton1.Click += cardsButton_Click;
            cardsButton2.Click += cardsButton_Click;
            cardsButton3.Click += cardsButton_Click;

            Ship = new Spaceship( 1 );
            StoreSegments = new SpaceshipSegment[2];
            foreach( Tuple<int, int> coord in Ship.ValidCells ) {
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
                tableLayoutPanel1.Controls.Add( pictureBox, coord.Item2, coord.Item1 );
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Margin = new Padding( 1 );
                pictureBox.AllowDrop = true;
                pictureBox.DragEnter += pictureBox_DragEnter;
                pictureBox.DragDrop += pictureBox_DragDrop;
            }

            PictureBox cabinControl = (PictureBox)tableLayoutPanel1.GetControlFromPosition( 
                Ship.MainCabinPosition.Item2, Ship.MainCabinPosition.Item1 );
            cabinControl.AllowDrop = false;
            cabinControl.Image = Ship.Matrix[Ship.MainCabinPosition.Item1, Ship.MainCabinPosition.Item2].Image;

            for( int i = 0; i < openPanel.RowCount; i++ ) {
                for( int j = 0; j < openPanel.ColumnCount; j++ ) {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
                    openPanel.Controls.Add( pictureBox, j, i );
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Margin = new Padding( 1 );
                    pictureBox.MouseDown += openPanelPictureBox_MouseDown;
                }
            }

            openedSegments = new List<SpaceshipSegment>();
        }

        private async void startButton_Click( object sender, EventArgs e )
        {
            connection = new ServerConnection();
            connection.Start();
            if( connection.IsConnected ) {
                LobbyDialog lobbyDialog = new LobbyDialog( connection );
                lobbyDialog.Owner = this;
                Task<int> lobbyTask = connection.QueryLobby( lobbyDialog );
                lobbyDialog.ShowDialog();
                await lobbyTask;
                lobbyDialog.Close();
                if( lobbyTask.Result == 0 ) {
                    this.menuPanel.Visible = false;
                    this.constructorPanel.Visible = true;
                    connection.BackgroundLoop();
                    listenOpenPanel();
                    timerOfConstructionPhase.Start();
                }
            }
        }

        private void exitButton_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private async void btnGetSegment_Click( object sender, EventArgs e )
        {
            if( queuePictureBox.Image == null && !isReady ) {
                Task<string> taskMessage = connection.GetSegment();
                await taskMessage;
                if( !taskMessage.Result.Equals( "Empty" ) ) {
                    CurrentSegment = new SpaceshipSegment( taskMessage.Result.Split( ':' )[1] );
                    queuePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    queuePictureBox.Image = CurrentSegment.Image;
                }
            } 
        }

        private void queuePictureBox_MouseDown( object sender, MouseEventArgs e )
        {
            var img = queuePictureBox.Image;
            if( img == null ) return;
            DraggingSegment = CurrentSegment;
            if( DoDragDrop( img, DragDropEffects.Move ) == DragDropEffects.Move ) {
                queuePictureBox.Image = null;
            }
        }

        private void MainWindow_DragEnter( object sender, DragEventArgs e )
        {
            e.Effect = DragDropEffects.None;
        }

        private void pictureBox_DragEnter( object sender, DragEventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition( pictureBox );
            if( e.Data.GetDataPresent( DataFormats.Bitmap ) && 
                Ship.CanAddSegment( DraggingSegment, pos.Row, pos.Column ) && !isReady ) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox_DragDrop( object sender, DragEventArgs e )
        {
            var bmp = (Bitmap)e.Data.GetData( DataFormats.Bitmap );
            PictureBox pictureBox = (PictureBox)sender;
            TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition( pictureBox );
            Ship.AddSegment( DraggingSegment, pos.Row, pos.Column );
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = bmp;
            pictureBox.AllowDrop = false;
        }

        private void storePictureBox_DragEnter( object sender, DragEventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            if( e.Data.GetDataPresent( DataFormats.Bitmap ) && pictureBox.Image == null &&
                ( StoreSegments[0] == null || StoreSegments[1] == null ) && !isReady ) 
            {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void storePictureBox_DragDrop( object sender, DragEventArgs e )
        {
            var bmp = (Bitmap)e.Data.GetData( DataFormats.Bitmap );
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = bmp;
            if( pictureBox.Name == "storePictureBox1" ) {
                StoreSegments[0] = DraggingSegment;
            } else {
                StoreSegments[1] = DraggingSegment;
            }
        }

        private void storePictureBox_MouseDown( object sender, MouseEventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            var img = pictureBox.Image;
            if( img == null ) return;
            if( pictureBox.Name == "storePictureBox1" ) {
                DraggingSegment = StoreSegments[0];
            } else {
                DraggingSegment = StoreSegments[1];
            }
            if( DoDragDrop( img, DragDropEffects.Move ) == DragDropEffects.Move ) {
                pictureBox.Image = null;
                if( pictureBox.Name == "storePictureBox1" ) {
                    StoreSegments[0] = null;
                } else {
                    StoreSegments[1] = null;
                }
            }
        }

        private void openPanel_DragEnter( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.Bitmap ) && !isReady ) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void openPanel_DragDrop( object sender, DragEventArgs e )
        {
            connection.SendOpenSegment( DraggingSegment.Serialize() );
        }

        private void openPanelPictureBox_MouseDown( object sender, MouseEventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            var img = pictureBox.Image;
            if( img == null || isReady ) return;
            TableLayoutPanelCellPosition pos = openPanel.GetCellPosition( pictureBox );
            DraggingSegment = openedSegments[pos.Row * 12 + pos.Column];
            connection.RemoveOpenSegment( DraggingSegment.Serialize() );
            
            if( DoDragDrop( img, DragDropEffects.Move ) != DragDropEffects.Move ){
                connection.SendOpenSegment( DraggingSegment.Serialize() );
            }
        }

        private async void listenOpenPanel()
        {
            Task<string> task = connection.ListenForMessages( new string[] { "OpenAdd", "OpenRemove" } );
            await task;
            string message = task.Result;
            string segemnt = message.Split( ':' )[1];
            if( message.IndexOf( "OpenAdd" ) != -1 ) {
                openedSegments.Add( new SpaceshipSegment( message.Split( ':' )[1] ) );
            } else if( message.IndexOf( "OpenRemove" ) != -1 ) {
                for( int i = 0; i < openedSegments.Count; i++ ) {
                    if( openedSegments[i].Equals( new SpaceshipSegment( message.Split( ':' )[1] ) ) ) {
                        openedSegments.RemoveAt( i );
                        break;
                    }
                }
            }
            redrawOpenPanel();
            listenOpenPanel();
        }

        private void redrawOpenPanel()
        {
            for( int i = 0; i < openPanel.RowCount; i++ ) {
                for( int j = 0; j < openPanel.ColumnCount; j++ ) {
                    PictureBox pictureBox = (PictureBox)openPanel.GetControlFromPosition( j, i );
                    int m = i * 12 + j;
                    if( m < openedSegments.Count ) {
                        pictureBox.Image = openedSegments[m].Image;
                    } else {
                        pictureBox.Image = null;
                    }
                }
            }
        }

        private async void cardsButton_Click( object sender, EventArgs e )
        {
            if( isReady ) return;
            Task<string> task;
            Button btn = (Button)sender;
            if( btn.Name == "cardsButton1" ) {
                task = connection.GetCards( 1 );
            } else if( btn.Name == "cardsButton2" ) {
                task = connection.GetCards( 2 );
            } else {
                task = connection.GetCards( 3 );
            }
            await task;
            string cardsString = task.Result.Split( '#' )[1];
            List<Card> cards = new List<Card>();
            foreach( string card in cardsString.Split('@') ) {
                if( !card.Equals( "" ) ) {
                    if( card.IndexOf( "OpenSpace" ) != -1 ) {
                        cards.Add( new OpenSpaceCard() );
                    }
                    if( card.IndexOf( "Dust" ) != -1 ) {
                        cards.Add( new OpenSpaceCard() );
                    }
                    if( card.IndexOf( "Planets" ) != -1 ) {
                        cards.Add( new PlanetsCard( card.Split( ':' )[1] ) );
                    }
                    if( card.IndexOf( "Damage" ) != -1 ) {
                        cards.Add( new DamageCard( card.Split( ':' )[1] ) );
                    }
                }
            }
            new CardsView( cards ).ShowDialog();
        }

        private void timerOfConstructionPhase_Tick( object sender, EventArgs e )
        {
            if( timeLeft > 0 ) {
                timeLeft = timeLeft - 1;
                timeLabel.Text = "Time left: " + timeLeft + " seconds";
            } else {
                timerOfConstructionPhase.Stop();
                timeLabel.Text = "Time's up!";
            }
        }

        private void readyButton_Click( object sender, EventArgs e )
        {
            if( connection.SendReady() ) {
                Button btn = (Button)sender;
                btn.Enabled = false;
                isReady = true;
            }
        }
    }
}
