using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GalaxyTruckerServer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    using System.Threading;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace HTTPServer
    {
        class ClientInfo
        {
            public TcpClient Connection;
            public string Name = "Player 1";
            public ClientInfo( TcpClient _connection, string _name)
            {
                Connection = _connection;
                Name = _name;
            }

            public bool IsConnected
            {
                get
                {
                    try {
                        if( Connection != null && Connection.Client != null && Connection.Client.Connected ) {
                            if( Connection.Client.Poll( 0, SelectMode.SelectRead ) ) {
                                byte[] buff = new byte[1];
                                if( Connection.Client.Receive( buff, SocketFlags.Peek ) == 0 ) {
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
        }
        class Server
        {
            int Port = 8000;
            List<ClientInfo> clients = new List<ClientInfo>();
            GameState state = new GameState();
            public Server( int _port )
            {
                Port = _port;
            }

            public void Start()
            {
                TcpListener listener = new TcpListener( IPAddress.Any, Port );
                listener.Start();
                int counter = 0;
                while( true ) {
                    if( listener.Pending() ) {
                        TcpClient client = listener.AcceptTcpClient();
                        counter += 1;
                        clients.Add( new ClientInfo( client, "Player " + counter.ToString() ) );
                    }

                    List<int> toBeRemoved = new List<int>();
                    foreach( ClientInfo client in clients ) {
                        if( !client.IsConnected ) {
                           toBeRemoved.Add( clients.IndexOf( client ) );
                        }
                    }
                    foreach( int index in toBeRemoved ) {
                        clients.RemoveAt( index );
                    }

                    foreach( ClientInfo client in clients ) {
                        string request = read( client.Connection );
                        if( !request.Equals( "" ) ) {
                            Console.WriteLine( "[Server] " + client.Name + " wrote: '{0}'", request );
                            if( request == "IsLobbyReady\r\n" ) {
                                if( clients.Count == 1 ) {
                                    string answer = "Yes\r\n";
                                    Console.WriteLine( "[Server] Sent to " + client.Name + " : '{0}'", answer );
                                    send( client.Connection, answer );
                                } else {
                                    string answer = "No\r\n";
                                    Console.WriteLine( "[Server] Sent to " + client.Name + " : '{0}'", answer );
                                    send( client.Connection, answer );
                                }
                            } else if( request == "GetSegment\r\n" ) {
                                string answer = state.Queue.Get().CustomToString() + "\r\n";
                                Console.WriteLine( "[Server] Sent to " + client.Name + " : '{0}'", answer );
                                send( client.Connection, answer );
                            }
                        }
                        
                    }
                    Thread.Sleep( 20 );
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
        class Program
        {
            static void Main( string[] args )
            {
                Server server = new Server(8000);
                server.Start();
            }
        }
    }

}
