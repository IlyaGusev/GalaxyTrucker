using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTruckerClient
{
    class Player
    {
        public int PositionOnTrack { get; set; }
        public Spaceship Ship { get; set; }
        public List<SpaceshipSegment> Garbage { get; set; }
        public int Money { get; set; }
    }
}
