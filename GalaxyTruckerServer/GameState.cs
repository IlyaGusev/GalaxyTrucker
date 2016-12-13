using GalaxyTruckerClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTruckerServer
{
    class GameState
    {
        public enum TPhase{ Construction, Action };
        public TPhase Phase { get; set; }
        public SpaceshipConstructionQueue Queue = new SpaceshipConstructionQueue( new List<string>{
                "Blaster0001000", "Cabin0323220","Engine2300000", "Cabin0323220",
                "Hold0000220",  "Engine2300000", "Blaster0001000"} );
        public List<List<string>> CardCollelctions = new List<List<string>>();
        public TupleList<int, string> PlayersPositions = new TupleList<int, string>();

        public GameState()
        {
            var rnd = new Random();
            List<Card> cardPool = new List<Card> { new OpenSpaceCard(), new OpenSpaceCard(), new DustCard(),
                new PlanetsCard("0111;0222;0333;3"), new DamageCard( "a;01;02;03;04"), new PlanetsCard("111;222;3333;2"),
                new OpenSpaceCard(), new OpenSpaceCard() };
            cardPool = new List<Card>( cardPool.OrderBy( item => rnd.Next() ) );
            CardCollelctions.Add( new List<string> { cardPool[0].Serialize(), cardPool[1].Serialize() } );
            CardCollelctions.Add( new List<string> { cardPool[2].Serialize(), cardPool[3].Serialize() } );
            CardCollelctions.Add( new List<string> { cardPool[4].Serialize(), cardPool[5].Serialize() } );
        }
    }
}
