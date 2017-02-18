using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class AcornPattern : IPattern
    {
        public string Name { get { return "Acorn"; } }

        public void DrawPattern(Cell atCell)
        {
            atCell.SetNextIsAlive(true)
                .MarkEastAlive()
                .North
                .MarkNorthAlive()
                .SouthEast
                .MarkEastAlive()
                .MarkSouthEastAlive()
                .MarkEastAlive()
                .MarkEastAlive();
        }
    }
}
