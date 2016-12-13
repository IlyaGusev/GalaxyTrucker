using GalaxyTruckerClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTruckerServer
{
    class SpaceshipConstructionQueue
    {
        public SpaceshipConstructionQueue( List<string> _closedQueueOfSegments )
        {
            ClosedQueueOfSegments = _closedQueueOfSegments;
            OpenedSegments = new List<string>();
        }

        public string Get()
        {
            var rnd = new Random( Convert.ToInt32( DateTime.Now ) );
            ClosedQueueOfSegments = new List<string>( ClosedQueueOfSegments.OrderBy( item => rnd.Next() ) );
            string res = ClosedQueueOfSegments[0];
            ClosedQueueOfSegments.RemoveAt( 0 );
            return res;
        }

        public int Count()
        {
            return ClosedQueueOfSegments.Count;
        }

        public List<string> ClosedQueueOfSegments;
        public List<string> OpenedSegments;
    }
}
