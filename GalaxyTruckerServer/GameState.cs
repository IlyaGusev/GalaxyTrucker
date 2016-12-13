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
        List<List<Card>> cardCollelction = new List<List<Card>>();

        public GameState()
        {
            var rnd = new Random( Convert.ToInt32( DateTime.Now ) );
            List<Card> cardPool = new List<Card> { new OpenSpaceCard(), new OpenSpaceCard(), new DustCard(),
                new PlanetsCard("0111;0222;0333;3"), new DamageCard( "a;01;02;03;04"), new PlanetsCard("111;222;3333"),
                new OpenSpaceCard(), new OpenSpaceCard() };
            cardPool = new List<Card>( cardPool.OrderBy( item => rnd.Next() ) );
            cardCollelction.Add( new List<Card> { cardPool[0], cardPool[1] } );
            cardCollelction.Add( new List<Card> { cardPool[2], cardPool[3] } );
            cardCollelction.Add( new List<Card> { cardPool[4], cardPool[5] } );
        }
    }
}
