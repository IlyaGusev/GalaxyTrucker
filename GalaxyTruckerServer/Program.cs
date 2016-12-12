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
            TcpListener listener;
            public Server( int _port )
            {
                Port = _port;
            }

            public void Start()
            {
                listener = new TcpListener( IPAddress.Any, Port );
                listener.Start();
                loop();
            }

            private void loop()
            {
                int counter = 0;
                while( true ) {
                    if( listener.Pending() ) {
                        TcpClient connection = listener.AcceptTcpClient();
                        counter += 1;
                        ClientInfo client = new ClientInfo( connection, "Player " + counter.ToString() );
                        clients.Add( client );
                        logConnect( client );
                    }

                    List<int> toBeRemoved = new List<int>();
                    foreach( ClientInfo client in clients ) {
                        if( !client.IsConnected ) {
                            toBeRemoved.Add( clients.IndexOf( client ) );
                            logDisconnect( client );
                        }
                    }
                    clients.RemoveAll( x => toBeRemoved.IndexOf( clients.IndexOf( x ) ) != -1 );

                    foreach( ClientInfo client in clients ) {
                        string request = recieve( client );
                        if( !request.Equals( "" ) ) {
                            logRecieve( client, request );
                            if( request == "IsLobbyReady" ) {
                                if( clients.Count == 1 ) {
                                    send( client, "Yes" );
                                } else {
                                    send( client, "No" );
                                }
                            } else if( request == "GetSegment" ) {
                                if( state.Queue.Count() != 0 ) {
                                    send( client, "Segment:" + state.Queue.Get() );
                                } else {
                                    send( client, "Empty" );
                                }
                            } else if( request.IndexOf("Open") != -1  ) {
                                foreach( ClientInfo cl in clients ) {
                                    send( cl, request );
                                }
                            }
                        }

                    }
                    Thread.Sleep( 20 );
                }
            }

            private void logSend( ClientInfo client, string message )
            {
                Console.WriteLine( "To " + client.Name + " : '{0}'", message);
            }
            private void logRecieve( ClientInfo client, string message )
            {
                Console.WriteLine( "From " + client.Name + " : '{0}'", message );
            }

            private void logConnect( ClientInfo client )
            {
                Console.WriteLine( client.Name + " connected" );
            }

            private void logDisconnect( ClientInfo client )
            {
                Console.WriteLine( client.Name + " disconnected" );
            }

            private void send( ClientInfo client, string str )
            {
                if( client.IsConnected ) {
                    byte[] Buffer = Encoding.ASCII.GetBytes( str );
                    client.Connection.GetStream().Write( Buffer, 0, Buffer.Length );
                    logSend( client,str );
                }
            }

            private string recieve( ClientInfo client )
            {
                string request = "";
                try {
                    if( client.IsConnected && client.Connection.GetStream().DataAvailable ) {
                        byte[] buffer = new byte[1024];
                        int count = client.Connection.GetStream().Read( buffer, 0, buffer.Length );
                        request += Encoding.ASCII.GetString( buffer, 0, count );
                    }
                } catch {
                    return request;
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
