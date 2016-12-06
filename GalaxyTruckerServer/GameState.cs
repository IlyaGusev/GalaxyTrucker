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
        public SpaceshipConstructionQueue Queue { get; set; }
        public GameState()
        {
            Queue = new SpaceshipConstructionQueue( new List<SpaceshipSegment>{
                new SpaceshipSegment("Blaster0001000"), new SpaceshipSegment("Cabin0323220"),
                new SpaceshipSegment("Engine2300000"), new SpaceshipSegment("Cabin0323220"),
                new SpaceshipSegment("Hold0000220"),  new SpaceshipSegment("Engine2300000"),
                new SpaceshipSegment("Blaster0001000")} );
        }
    }
}
