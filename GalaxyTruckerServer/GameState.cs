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
            Queue = new SpaceshipConstructionQueue( new List<string>{
                "Blaster0001000", "Cabin0323220","Engine2300000", "Cabin0323220",
                "Hold0000220",  "Engine2300000", "Blaster0001000"} );
        }
    }
}
