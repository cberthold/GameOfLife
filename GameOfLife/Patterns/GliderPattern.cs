using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class GliderPattern : IPattern
    {
        public string Name { get { return "Glider"; } }

        public void DrawPattern(Cell atCell)
        {
            atCell.SetNextIsAlive(true);

            atCell.MarkEastAlive()
                .MarkEastAlive()
                .MarkNorthAlive()
                .MarkNorthWestAlive();
        }
    }
}
