using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GalaxyTruckerClient
{
    public class ServerConnection
    {
        TcpClient serverConnection;
        CancellationTokenSource cancelTokenSource;

        public void Start()
        {
            try {
                serverConnection = new TcpClient( "127.0.0.1", 8000 );
            } catch {

            }
        }

        public Task<int> QueryLobby( LobbyDialog lobbyDialog )
        {
            cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;
            return Task.Run( () => {
                int result = -1;
                while( true ) {
                    if( !this.IsConnected ) {
                        lobbyDialog.Invoke( new Action( () => {
                            lobbyDialog.Close();
                        } ) );
                        
                        break;
                    }
                    send( serverConnection, "IsLobbyReady\r\n" );
                    if( read( serverConnection ) == "Yes\r\n" ) {
                        result = 0;
                        lobbyDialog.Invoke( new Action( () => {
                            lobbyDialog.Close();
                        } ) );
                        break;
                    }
                    if( token.IsCancellationRequested ) {
                        serverConnection.Close();
                        break;
                    }
                    Thread.Sleep( 100 );
                }
                return result;
            }, token);
        }

        public void CancelLobby()
        {
            cancelTokenSource.Cancel();
        }

        public string GetSegment()
        {
            if( !this.IsConnected ) {
                return "";
            }
            send( serverConnection, "GetSegment\r\n" );
            return read( serverConnection );
        }

        public bool IsConnected
        {
            get
            {
                try {
                    if( serverConnection != null && serverConnection.Client != null && serverConnection.Client.Connected ) {
                        if( serverConnection.Client.Poll( 0, SelectMode.SelectRead ) ) {
                            byte[] buff = new byte[1];
                            if( serverConnection.Client.Receive( buff, SocketFlags.Peek ) == 0 ) {
                                return false;
                            } else {
                                return true;
                            }
                        }
                        return true;
                    } else {
                        return false;
                    }
                } catch {
                    return false;
                }
            }
        }

        private void send( TcpClient client, string str )
        {
            byte[] Buffer = Encoding.ASCII.GetBytes( str );
            client.GetStream().Write( Buffer, 0, Buffer.Length );
        }

        private string read( TcpClient client )
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
    }
}
