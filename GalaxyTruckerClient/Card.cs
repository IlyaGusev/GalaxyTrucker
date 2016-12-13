using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTruckerClient
{
    public class Card
    {
        public enum TCargo { Red, Yellow, Green, Blue };
        public enum TAsteroids { Big, Small }
        public enum TBooms { Big, Small }
        public enum TDirection { Up, Right, Down, Left }
    }

    public class OpenSpaceCard : Card
    {

    }

    public class EpedemyCard : Card
    {

    }

    public class DustCard : Card
    {

    }

    public class DamageCard : Card
    {
        public DamageCard( string st )
        {
            if( st[0] == 'b' ) {
                List<string> booms = new List<string>( st.Split( ';' ) );
                booms = booms.GetRange( 1, booms.Count - 1 );
                foreach( string boom in booms ) {
                    Booms.Add( new Tuple<TAsteroids, TDirection>( (TAsteroids)Int32.Parse( boom[0].ToString() ), 
                        (TDirection)Int32.Parse( boom[1].ToString() ) ) );
                }
            } else if( st[0] == 'a' ) {
                List<string> asteroids = new List<string>( st.Split( ';' ) );
                asteroids = asteroids.GetRange( 1, asteroids.Count - 1 );
                foreach( string asteroid in asteroids ) {
                    Booms.Add( new Tuple<TAsteroids, TDirection>( (TAsteroids)Int32.Parse( asteroid[0].ToString() ),
                        (TDirection)Int32.Parse( asteroid[1].ToString() ) ) );
                }
            }
        }
        public TupleList<TAsteroids, TDirection> Asteroids { get; set; }
        public TupleList<TAsteroids, TDirection> Booms { get; set; }
    }

    public class PlanetsCard : Card
    {
        public PlanetsCard( List<List<TCargo>> _planets, int _costMovement )
        {
            Planets = _planets;
            CostMovement = _costMovement;
        }

        public PlanetsCard( string st )
        {
            List<string> planetsAndCost = new List<string>( st.Split( ';' ) );
            for( int i = 0; i < planetsAndCost.Count - 1; i++ ) {
                List<TCargo> planet = new List<TCargo>();
                foreach( char ch in planetsAndCost[i] ) {
                    planet.Add( (TCargo)Int32.Parse( ch.ToString() ) );
                }
            }
            CostMovement = Convert.ToInt32( planetsAndCost[planetsAndCost.Count - 1] );
        }
        public List<List<TCargo>> Planets { get; set; }
        public int CostMovement { get; set; }
    }

    public class CompareCard : Card
    {
        public enum TComparing {Engine, Weapon, Crew}
        public List<TComparing> Comparings { get; set; }
        public List<int> PenaltyCargo { get; set; }
        public List<int> PenaltyCrew { get; set; }
        public List<int> PenaltyMovement { get; set; }
    }

    public class RequirementsCard : Card
    {
        public int RequireEnginePower { get; set; }
        public int RequireWeaponPower { get; set; }
        public int RequireCrew { get; set; }

        public List<TCargo> RewardCargo { get; set; }
        public int RewardMoney { get; set; }

        public int PenaltyCargo { get; set; }
        public int PenaltyCrew { get; set; }
        public int PenaltyMovement { get; set; }
        public TupleList<TAsteroids, TDirection> PenaltyAsteroids { get; set; }
        public TupleList<TAsteroids, TDirection> PenaltyBooms { get; set; }

        public int CostMovement { get; set; }
        public int CostCrew { get; set; }
    }
}
