using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class BeehivePattern : IPattern
    {
        public string Name { get { return "Beehive"; } }

        public void DrawPattern(Cell atCell)
        {
            atCell.SetNextIsAlive(true);

            atCell.MarkNorthEastAlive()
                .MarkEastAlive()
                .MarkSouthEastAlive();

            atCell.MarkSouthEastAlive()
                .MarkEastAlive()
                .MarkNorthEastAlive();
        }
    }
}
