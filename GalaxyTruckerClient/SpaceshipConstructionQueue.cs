using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyTruckerClient
{
    class SpaceshipConstructionQueue
    {
        public SpaceshipConstructionQueue( List<SpaceshipSegment> _closedQueueOfSegments )
        {
            ClosedQueueOfSegments = _closedQueueOfSegments;
            OpenedSegments = new List<SpaceshipSegment>();
        }

        public SpaceshipSegment Get()
        {
            var rnd = new Random();
            ClosedQueueOfSegments = new List<SpaceshipSegment>( ClosedQueueOfSegments.OrderBy( item => rnd.Next() ) );
            SpaceshipSegment res = ClosedQueueOfSegments[0];
            ClosedQueueOfSegments.RemoveAt( 0 );
            return res;
        }

        public int Count()
        {
            return ClosedQueueOfSegments.Count;
        }

        public List<SpaceshipSegment> ClosedQueueOfSegments;
        public List<SpaceshipSegment> OpenedSegments;
    }
}
