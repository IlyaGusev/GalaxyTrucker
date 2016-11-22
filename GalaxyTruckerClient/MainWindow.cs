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

namespace GalaxyTruckerClient
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

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

            Queue = new SpaceshipConstructionQueue(new List<SpaceshipSegment>{
                new SpaceshipSegment("Blaster0001000"), new SpaceshipSegment("Cabin0323220"),
                new SpaceshipSegment("Engine2300000"), new SpaceshipSegment("Cabin0323220"),
                new SpaceshipSegment("Hold0000220"),  new SpaceshipSegment("Engine2300000"),
                new SpaceshipSegment("Blaster0001000")} );

            queuePictureBox.MouseDown += queuePictureBox_MouseDown;
            storePictureBox1.DragEnter += storePictureBox_DragEnter;
            storePictureBox2.DragEnter += storePictureBox_DragEnter;
            storePictureBox1.DragDrop += storePictureBox_DragDrop;
            storePictureBox2.DragDrop += storePictureBox_DragDrop;
        }

        private void MainWindow_Load( object sender, EventArgs e )
        {

        }

        private void btnGetSegment_Click( object sender, EventArgs e )
        {
            if( Queue.Count() != 0) {
                CurrentSegment = Queue.Get();
                queuePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                queuePictureBox.Image = CurrentSegment.Image;
            } 
        }

        private void queuePictureBox_MouseDown( object sender, MouseEventArgs e )
        {
            var img = queuePictureBox.Image;
            if( img == null ) return;
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
                Ship.CanAddSegment( CurrentSegment, pos.Row, pos.Column ) ) {
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
            Ship.AddSegment( CurrentSegment, pos.Row, pos.Column );
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = bmp;
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
        }

        SpaceshipSegment CurrentSegment { get; set; }
        SpaceshipSegment[] StoreSegments { get; set; }
        Spaceship Ship { get; set; }
        SpaceshipConstructionQueue Queue{ get; set; }
    }
}
