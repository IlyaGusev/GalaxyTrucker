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
    public partial class LobbyDialog : Form
    {
        ServerConnection _connection;
        public LobbyDialog( ServerConnection connection )
        {
            _connection = connection;
            InitializeComponent();
        }

        private void cancelButton_Click( object sender, EventArgs e )
        {
            MainWindow wnd = (MainWindow)this.Owner;
            this.Close();
        }

        private void LobbyDialog_FormClosed( object sender, FormClosedEventArgs e )
        {
            _connection.CancelLobby();
        }
    }
}
