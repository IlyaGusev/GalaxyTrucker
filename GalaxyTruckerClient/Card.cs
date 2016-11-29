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

    class OpenSpaceCard: Card
    {

    }

    class EpedemyCard: Card
    {

    }

    class DustCard: Card
    {

    }

    class DamageCard: Card
    {
        public TupleList<TAsteroids, TDirection> Asteroids { get; set; }
        public TupleList<TAsteroids, TDirection> Booms { get; set; }
    }

    class PlanetsCard: Card
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
                    planet.Add( (TCargo)Convert.ToInt32( ch ) );
                }
            }
            CostMovement = Convert.ToInt32( planetsAndCost[planetsAndCost.Count - 1] );
        }
        public List<List<TCargo>> Planets { get; set; }
        public int CostMovement { get; set; }
    }

    class CompareCard: Card
    {
        public enum TComparing {Engine, Weapon, Crew}
        public List<TComparing> Comparings { get; set; }
        public List<int> PenaltyCargo { get; set; }
        public List<int> PenaltyCrew { get; set; }
        public List<int> PenaltyMovement { get; set; }
    }

    class RequirementsCard: Card
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
