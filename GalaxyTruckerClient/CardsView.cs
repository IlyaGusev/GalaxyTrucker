using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyTruckerClient
{
    public partial class CardsView : Form
    {
        public CardsView( List<Card> cards )
        {
            InitializeComponent();
            for( int i = 0; i < cards.Count; i++ ) {
                Card card = cards[i];
                PictureBox pictureBox = new PictureBox();
                Label label = new Label();
                label.Text = card.GetType().Name;
                pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
                this.cardsPanel.Controls.Add( pictureBox, i, 1 );
                this.cardsPanel.Controls.Add( label, i, 0 );
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Margin = new Padding( 1 );
            }
        }
    }
}
