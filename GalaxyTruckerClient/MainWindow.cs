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
                new SpaceshipSegment("Hold0000220")} );

            queuePictureBox.MouseDown += queuePictureBox_MouseDown;
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
            e.Effect = DragDropEffects.Move;
        }

        void pictureBox_DragEnter( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.Bitmap ) )
                e.Effect = DragDropEffects.Move;
        }

        void pictureBox_DragDrop( object sender, DragEventArgs e )
        {
            var bmp = (Bitmap)e.Data.GetData( DataFormats.Bitmap );
            PictureBox pictureBox = (PictureBox)sender;
            TableLayoutPanelCellPosition pos = tableLayoutPanel1.GetCellPosition( pictureBox );
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = bmp;
        }

        SpaceshipSegment CurrentSegment { get; set; }
        Spaceship Ship { get; set; }
        SpaceshipConstructionQueue Queue{ get; set; }
    }
}
