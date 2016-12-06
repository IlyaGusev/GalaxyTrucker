using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTruckerClient
{
    public class SpaceshipSegment
    {
        public enum TType { Engine, DoubleEngine, Blaster, DoubleBlaster, Cabin, Hold, Batteries,
            Structure, DangerousHold, BrownCabin, PurpleCabin, Shield };
        public enum TSocket { No, Unary, Binary, Universal }
        public enum TDirection { Up, Right, Down, Left }

        public SpaceshipSegment( TType _type, TDirection _mainDirection, TSocket _socketUp, TSocket _socketRight, 
            TSocket _socketDown, TSocket _socketLeft, int _capacity = 0, int _current = 0, bool _isMain = false )
        {
            Type = _type;
            MainDirection = _mainDirection;
            SocketUp = _socketUp;
            SocketRight = _socketRight;
            SocketDown = _socketDown;
            SocketLeft = _socketLeft;
            Capacity = _capacity;
            Current = _current;
            IsActive = false;
            IsMain = _isMain;
            String id = Type + MainDirection.ToString( "D" ) + SocketUp.ToString( "D" ) + SocketRight.ToString( "D" ) + 
                SocketDown.ToString( "D" ) + SocketLeft.ToString( "D" ) + Capacity + Convert.ToInt32( IsMain );
            Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject( id );
        }

        public SpaceshipSegment( String st )
        {
            int d = -1;
            for( int i = 0; i < st.Length; i++ ) {
                if( Char.IsDigit( st[i] ) ) {
                    d = i;
                    break;
                }
            }
            String type = st.Substring( 0, d );
            String numbers = st.Substring( d );
            Type = (TType)Enum.Parse( typeof( TType ), type );
            MainDirection = (TDirection)Enum.Parse( typeof( TDirection ), "" + numbers[0] );
            SocketUp = (TSocket)Enum.Parse( typeof( TSocket ), "" + numbers[1] );
            SocketRight = (TSocket)Enum.Parse( typeof( TSocket ), "" + numbers[2] );
            SocketDown = (TSocket)Enum.Parse( typeof( TSocket ), "" + numbers[3] );
            SocketLeft = (TSocket)Enum.Parse( typeof( TSocket ), "" + numbers[4] );
            Capacity = Convert.ToInt32( numbers[5] );
            IsMain = Convert.ToBoolean( Convert.ToInt32( numbers[6] ) );
            Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject( st );
        }

        public string CustomToString()
        {
            return Type.ToString() + MainDirection.ToString() + SocketUp.ToString();
        }

        public Tuple<TSocket, TSocket> CalculateSockets( SpaceshipSegment other, TDirection direction )
        {
            TSocket socket1 = this.SocketUp;
            TSocket socket2 = other.SocketDown;
            if( direction == TDirection.Right ) {
                socket1 = this.SocketRight;
                socket2 = other.SocketLeft;
            }
            if( direction == TDirection.Down ) {
                socket1 = this.SocketDown;
                socket2 = other.SocketUp;
            }
            if( direction == TDirection.Left ) {
                socket1 = this.SocketLeft;
                socket2 = other.SocketRight;
            }
            return new Tuple<TSocket, TSocket>( socket1, socket2 );
        }

        public bool CanPlace( SpaceshipSegment other, TDirection direction )
        {
            Tuple<TSocket, TSocket> sockets = CalculateSockets( other, direction );
            TSocket socket1 = sockets.Item1;
            TSocket socket2 = sockets.Item2;

            return ( socket1 == socket2 ||
                     ( socket2 == SpaceshipSegment.TSocket.Universal && socket1 != SpaceshipSegment.TSocket.No ) ||
                     ( socket1 == SpaceshipSegment.TSocket.Universal && socket2 != SpaceshipSegment.TSocket.No ) );
        }

        public bool CanConnect( SpaceshipSegment other, TDirection direction )
        {
            Tuple<TSocket, TSocket> sockets = CalculateSockets( other, direction );
            TSocket socket1 = sockets.Item1;
            TSocket socket2 = sockets.Item2;

            return CanPlace( other, direction ) &&
                socket1 != SpaceshipSegment.TSocket.No &&
                socket2 != SpaceshipSegment.TSocket.No;
        }

        public TType Type { get; set; }
        public TDirection MainDirection { get; set; }
        public TSocket SocketUp { get; set; }
        public TSocket SocketRight { get; set; }
        public TSocket SocketDown { get; set; }
        public TSocket SocketLeft { get; set; }
        public int Capacity { get; set; }
        public int Current { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public System.Drawing.Bitmap Image { get; set; }
    }
}
