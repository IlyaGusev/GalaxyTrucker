using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GameState
    {
        public enum TPhase{ Construction, Action };
        public TPhase Phase { get; set; }
    }
}
