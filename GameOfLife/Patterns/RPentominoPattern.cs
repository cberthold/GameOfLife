using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class RPentominoPattern : IPattern
    {
        public string Name { get { return "RPentomino"; } }

        public void DrawPattern(Cell atCell)
        {
            atCell
                .MarkSouthAlive()
                .MarkSouthEastAlive()
                .MarkNorthAlive()
                .MarkNorthAlive()
                .MarkEastAlive();
        }
    }
}
