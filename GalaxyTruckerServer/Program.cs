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
        class Client
        {
            private void Send( string str )
            {
                byte[] Buffer = Encoding.ASCII.GetBytes( str );
                connection.GetStream().Write( Buffer, 0, Buffer.Length );
            }

            public Client( TcpClient _connection )
            {
                this.connection = _connection;
            }

            public void ClientLoop()
            {
                try {
                    while( true ) {
                        string request = "";
                        byte[] buffer = new byte[1024];
                        int count;
                        while( ( count = connection.GetStream().Read( buffer, 0, buffer.Length ) ) > 0 ) {
                            request += Encoding.ASCII.GetString( buffer, 0, count );
                            if( request.IndexOf( "\r\n" ) >= 0 || request.Length > 4096 ) {
                                break;
                            }
                        }
                        Console.WriteLine( "[Server] Client wrote {0}", request );

                        if( request == "Ready\r\n" ) {

                        } else if( request == "GetSegment\r\n" ) {

                        } else if( request == "GetCard\r\n" ) {

                        } else if( request == "Close\r\n" ) {
                            connection.Close();
                        } else if( request == "IsLobbyReady\r\n" ) {
                            if( Server.Clients.Count == 2 ) {
                                this.Send( "Yes\r\n" );
                            }
                        }
                    }
                } catch(System.IO.IOException e) {
                } finally {
                    connection.Close();
                }
            }

            private TcpClient connection { get; set; }
            public bool IsReady { get; set; }
        }

        class Server
        {
            public Server( int Port )
            {
                Listener = new TcpListener( IPAddress.Any, Port );
                Listener.Start();
                while( true ) {
                    ThreadPool.QueueUserWorkItem( new WaitCallback( ClientThread ), Listener.AcceptTcpClient() );
                }
            }
            static void ClientThread( Object StateInfo )
            {
                Console.WriteLine( "Client joined" );
                Client client = new Client( (TcpClient)StateInfo );
                Clients.Add( client );
                client.ClientLoop();
            }
            ~Server()
            {
                if( Listener != null ) {
                    Listener.Stop();
                }
            }

            static void Main( string[] args )
            {
                int MaxThreadsCount = 5;
                ThreadPool.SetMaxThreads( MaxThreadsCount, MaxThreadsCount );
                ThreadPool.SetMinThreads( 2, 2 );
                Server.Clients = new List<Client>();
                new Server( 8000 );
            }

            TcpListener Listener;
            public static List<Client> Clients;
        }
    }

}
