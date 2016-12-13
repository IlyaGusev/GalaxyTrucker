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
        List<string> buffer = new List<string>();

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
                    send( "IsLobbyReady" );
                    if( read() == "Yes" ) {
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

        public void BackgroundLoop()
        {
            Task.Run( () => {
                while( true ) {
                    if( !this.IsConnected ) {
                        break;
                    }
                    string message = read();
                    if( !message.Equals( "" ) ) {
                        buffer.Add( message );
                    }
                    Thread.Sleep( 100 );
                }
            });
        }

        public Task<string> ListenForMessages( string[] messages )
        {
            return Task.Run( () => {
                while( true ) {
                    if( buffer.Count != 0 ) {
                        for( int i = 0; i < buffer.Count; i++ ) {
                            foreach( string message in messages ) {
                                if( buffer[i].IndexOf( message ) != -1 ) {
                                    string temp = buffer[i];
                                    buffer.RemoveAt( i );
                                    return temp;
                                }
                            }
                            
                        }
                    }
                    Thread.Sleep( 100 );
                }
            } );
        }

        public void CancelLobby()
        {
            cancelTokenSource.Cancel();
        }

        public Task<string> GetSegment()
        {
            if( !this.IsConnected ) {
                return new Task<string>(() => "");
            }
            send( "GetSegment" );
            return ListenForMessages( new string[] { "Segment", "Empty" } );
        }

        public void SendOpenSegment( string segment )
        {
            send( "OpenAdd:" + segment );
        }

        public void RemoveOpenSegment( string segment )
        {
            send( "OpenRemove:" + segment );
        }

        public Task<string> GetCards( int collection )
        {
            if( !this.IsConnected ) {
                return new Task<string>( () => "" );
            }
            send( "GetCards:" + collection.ToString() );
            return ListenForMessages( new string[] { "Cards", "EmptyCards" } );
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

        private void send( string str )
        {
            if( IsConnected ) {
                byte[] Buffer = Encoding.ASCII.GetBytes( str );
                serverConnection.GetStream().Write( Buffer, 0, Buffer.Length );
            }
        }

        private string read()
        {

            string request = "";
            try {
                if( IsConnected ) {
                    byte[] buffer = new byte[1024];
                    int count = serverConnection.GetStream().Read( buffer, 0, buffer.Length );
                    request += Encoding.ASCII.GetString( buffer, 0, count );
                }
            } catch {
                return request;
            }
            return request;
        }
    }
}
