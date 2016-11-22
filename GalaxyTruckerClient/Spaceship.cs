using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTruckerClient
{
    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add( T1 item, T2 item2 )
        {
            Add( new Tuple<T1, T2>( item, item2 ) );
        }
    }

    class Spaceship
    {
        public Spaceship( int number )
        {
            if( number == 1 ) {
                ValidCells = new TupleList<int, int>
                {
                    { 3, 2 }, { 4, 2 }, { 5, 2 },
                    { 2, 3 }, { 3, 3 }, { 4, 3 }, { 5, 3 },
                    { 1, 4 }, { 2, 4 }, { 3, 4 }, { 4, 4 },
                    { 2, 5 }, { 3, 5 }, { 4, 5 }, { 5, 5 },
                    { 3, 6 }, { 4, 6 }, { 5, 6 }
                };
                MainCabinPosition = new Tuple<int, int>( 3, 4 );
                Matrix = new SpaceshipSegment[10, 10];
                Matrix[MainCabinPosition.Item1, MainCabinPosition.Item2] = new SpaceshipSegment( "Cabin0333321" );
            }
        }

        public bool CanAddSegment( SpaceshipSegment segment, int row, int col )
        {
            // Рядом с существующими сегментами
            if( Matrix[row - 1, col] == null && Matrix[row, col - 1] == null && 
                Matrix[row + 1, col] == null && Matrix[row, col + 1] == null ) 
            {
                return false;
            }
            // Нет противоречий
            if( ( row - 1 >= 0 && Matrix[row - 1, col] != null &&
                !Matrix[row - 1, col].CanPlace( segment, SpaceshipSegment.TDirection.Down ) ) ||
                ( col - 1 >= 0 && Matrix[row, col - 1] != null &&
                !Matrix[row, col - 1].CanPlace( segment, SpaceshipSegment.TDirection.Right ) ) ||
                ( row + 1 < Matrix.GetLength( 0 ) && Matrix[row + 1, col] != null ) &&
                !Matrix[row + 1, col].CanPlace( segment, SpaceshipSegment.TDirection.Up ) ||
                ( col + 1 < Matrix.GetLength( 1 ) && Matrix[row, col + 1] != null ) &&
                !Matrix[row, col + 1].CanPlace( segment, SpaceshipSegment.TDirection.Left ) ) 
            {
                return false;
            }
            // Есть связь
            if( ( row - 1 >= 0 && Matrix[row - 1, col] != null &&
                Matrix[row - 1, col].CanConnect( segment, SpaceshipSegment.TDirection.Down ) ) ||
                ( col - 1 >= 0 && Matrix[row, col - 1] != null &&
                Matrix[row, col - 1].CanConnect( segment, SpaceshipSegment.TDirection.Right ) ) ||
                ( row + 1 < Matrix.GetLength( 0 ) && Matrix[row + 1, col] != null ) &&
                Matrix[row + 1, col].CanConnect( segment, SpaceshipSegment.TDirection.Up ) ||
                ( col + 1 < Matrix.GetLength( 1 ) && Matrix[row, col + 1] != null ) &&
                Matrix[row, col + 1].CanConnect( segment, SpaceshipSegment.TDirection.Left ) ) 
            {
                return true;
            }
            return false;
        }

        public bool AddSegment( SpaceshipSegment segment, int row, int col )
        {
            if( !CanAddSegment(segment, row, col) ) {
                return false;
            }
            Matrix[row, col] = segment;
            return true;
        }

        public void Fill()
        {
            foreach( SpaceshipSegment segment in Matrix ) {
                if( segment != null ) {
                    segment.Current = segment.Capacity;
                }
            }
        }

        public int CountPeople()
        {
            int result = 0;
            foreach( SpaceshipSegment segment in Matrix ) {
                if( segment != null && (segment.Type == SpaceshipSegment.TType.Cabin || 
                    segment.Type == SpaceshipSegment.TType.BrownCabin ||
                    segment.Type == SpaceshipSegment.TType.PurpleCabin ) )
                {
                    result += segment.Current;
                }
            }
            return result;
        }

        public int CountEnergy()
        {
            int result = 0;
            foreach( SpaceshipSegment segment in Matrix ) {
                if( segment != null && segment.Type == SpaceshipSegment.TType.Batteries ) {
                    result += segment.Current;
                }
            }
            return result;
        }

        public int CountEnginePower()
        {
            int result = 0;
            foreach( SpaceshipSegment segment in Matrix ) {
                if( segment != null ) {
                    if( segment.Type == SpaceshipSegment.TType.Engine ) {
                        result += 1;
                    }
                    if( segment.Type == SpaceshipSegment.TType.DoubleEngine && segment.IsActive ) {
                        result += 2;
                    }
                    if( segment.Type == SpaceshipSegment.TType.BrownCabin && segment.Current == 1 ) {
                        result += 2;
                    }
                }
            }
            return result;
        }

        public double CountBlasterPower()
        {
            double result = 0;
            foreach( SpaceshipSegment segment in Matrix ) {
                if( segment != null ) {
                    if( segment.Type == SpaceshipSegment.TType.Blaster ) {
                        if( segment.MainDirection == SpaceshipSegment.TDirection.Up ) {
                            result += 1;
                        } else {
                            result += 0.5;
                        }
                    }
                    if( segment.Type == SpaceshipSegment.TType.DoubleBlaster && segment.IsActive ) {
                        if( segment.MainDirection == SpaceshipSegment.TDirection.Up ) {
                            result += 2;
                        } else {
                            result += 1;
                        }
                    }
                    if( segment.Type == SpaceshipSegment.TType.PurpleCabin && segment.Current == 1 ) {
                        result += 2;
                    }
                }
            }
            return result;
        }

        public SpaceshipSegment[,] Matrix { get; set; }
        public List<Tuple<int, int>> ValidCells { get; set; }
        public Tuple<int, int> MainCabinPosition { get; set; }
    }
}
