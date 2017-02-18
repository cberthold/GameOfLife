using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class BlinkerPattern : IPattern
    {
        public string Name { get { return "Blinker"; } }

        public void DrawPattern(Cell atCell)
        {
            atCell
                .SetNextIsAlive(true)
                .MarkEastAlive()
                .MarkEastAlive();
        }
    }
}
