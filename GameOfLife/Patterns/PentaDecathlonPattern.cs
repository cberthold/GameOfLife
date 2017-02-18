using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class PentaDecathlonPattern : IPattern
    {
        public string Name { get { return "Penta Decathlon"; } }

        public void DrawPattern(Cell atCell)
        {
            var col1 = atCell.MarkWestAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive();

            var col2 = atCell.SetNextIsAlive(true)
                .South
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .South
                .MarkSouthAlive();

            var col3 = atCell.MarkEastAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive()
                .MarkSouthAlive();
        }
    }
}
