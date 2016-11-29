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

namespace GalaxyTruckerClient
{
    public partial class MainWindow : Form
    {
        private void Send( TcpClient client, string str )
        {
            byte[] Buffer = Encoding.ASCII.GetBytes( str );
            client.GetStream().Write( Buffer, 0, Buffer.Length );
        }

        private string Read( TcpClient client )
        {
            string request = "";
            byte[] buffer = new byte[1024];
            int count;
            while( ( count = client.GetStream().Read( buffer, 0, buffer.Length ) ) > 0 ) {
                request += Encoding.ASCII.GetString( buffer, 0, count );
                if( request.IndexOf( "\r\n" ) >= 0 || request.Length > 4096 ) {
                    break;
                }
            }
            return request;
        }

        public MainWindow()
        {
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

            Queue = new SpaceshipConstructionQueue( new List<SpaceshipSegment>{
                new SpaceshipSegment("Blaster0001000"), new SpaceshipSegment("Cabin0323220"),
                new SpaceshipSegment("Engine2300000"), new SpaceshipSegment("Cabin0323220"),
                new SpaceshipSegment("Hold0000220"),  new SpaceshipSegment("Engine2300000"),
                new SpaceshipSegment("Blaster0001000")} );

            Cards1 = new List<Card> { new OpenSpaceCard(), new PlanetsCard("00;01;11;2") };
            Cards2 = new List<Card>();
            Cards3 = new List<Card>();
        }

        private void MainWindow_Load( object sender, EventArgs e )
        {
            //this.queuePictureBox.Enabled = false;
            //TcpClient client = new TcpClient( "127.0.0.1", 8000 );
            //Send( client, "IsLobbyReady\r\n" );
            //while( true ) {
            //    if( Read( client ) == "Yes\r\n" ) {
            //        this.queuePictureBox.Enabled = true;
            //        break;
            //    }
            //}
        }

        private void btnGetSegment_Click( object sender, EventArgs e )
        {
            if( Queue.Count() != 0 && queuePictureBox.Image == null ) {
                CurrentSegment = Queue.Get();
                queuePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                queuePictureBox.Image = CurrentSegment.Image;
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
                Ship.CanAddSegment( DraggingSegment, pos.Row, pos.Column ) ) {
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
                ( StoreSegments[0] == null || StoreSegments[1] == null ) ) 
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
            if( e.Data.GetDataPresent( DataFormats.Bitmap ) ) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void openPanel_DragDrop( object sender, DragEventArgs e )
        {
            var bmp = (Bitmap)e.Data.GetData( DataFormats.Bitmap );
            Queue.OpenedSegments.Add( DraggingSegment );
            RedrawOpenPanel();
        }

        private void openPanelPictureBox_MouseDown( object sender, MouseEventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            var img = pictureBox.Image;
            if( img == null ) return;
            TableLayoutPanelCellPosition pos = openPanel.GetCellPosition( pictureBox );
            DraggingSegment = Queue.OpenedSegments[pos.Row * 12 + pos.Column];
            Queue.OpenedSegments.RemoveAt( pos.Row * 12 + pos.Column );

            if( DoDragDrop( img, DragDropEffects.Move ) == DragDropEffects.Move ) {
                RedrawOpenPanel();
            } else {
                Queue.OpenedSegments.Add( DraggingSegment );
                RedrawOpenPanel();
            }
        }

        public void RedrawOpenPanel()
        {
            for( int i = 0; i < openPanel.RowCount; i++ ) {
                for( int j = 0; j < openPanel.ColumnCount; j++ ) {
                    PictureBox pictureBox = (PictureBox)openPanel.GetControlFromPosition( j, i );
                    int m = i * 12 + j;
                    if( m < Queue.OpenedSegments.Count ) {
                        pictureBox.Image = Queue.OpenedSegments[m].Image;
                    } else {
                        pictureBox.Image = null;
                    }
                }
            }
        }

        private void startButton_Click( object sender, EventArgs e )
        {
            this.menuPanel.Visible = false;
            this.constructorPanel.Visible = true;
        }

        private void exitButton_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void cardsButton_Click( object sender, EventArgs e )
        {
            Button btn = (Button)sender;
            if( btn.Name == "cardsButton1" ) {
                new CardsView( Cards1 ).ShowDialog();
            } else if( btn.Name == "cardsButton2" ) {
                new CardsView( Cards2 ).ShowDialog();
            } else if( btn.Name == "cardsButton3" ) {
                new CardsView( Cards3 ).ShowDialog();
            }
        }


        SpaceshipSegment DraggingSegment { get; set; }
        SpaceshipSegment CurrentSegment { get; set; }
        SpaceshipSegment[] StoreSegments { get; set; }
        Spaceship Ship { get; set; }
        SpaceshipConstructionQueue Queue { get; set; }
        List<Card> Cards1 { get; set; }
        List<Card> Cards2 { get; set; }
        List<Card> Cards3 { get; set; }
    }
}
