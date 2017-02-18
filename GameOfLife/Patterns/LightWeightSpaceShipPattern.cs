using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class LightWeightSpaceShipPattern : IPattern
    {
        public string Name { get { return "Light Weight Space Ship"; } }

        public void DrawPattern(Cell atCell)
        {
            var row1 = atCell
                .MarkEastAlive()
                .MarkEastAlive();

            var row2 = atCell
                .MarkSouthAlive()
                .MarkEastAlive()
                .MarkEastAlive()
                .MarkEastAlive();

            var row3 = atCell
                .South
                .MarkSouthAlive()
                .MarkEastAlive()
                .East
                .MarkEastAlive()
                .MarkEastAlive();

            var row4 = atCell
                .South
                .South
                .South
                .East
                .MarkEastAlive()
                .MarkEastAlive();
        }
    }
}
