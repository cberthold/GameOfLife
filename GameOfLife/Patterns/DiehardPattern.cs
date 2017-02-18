using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public class DiehardPattern : IPattern
    {
        public string Name { get { return "Diehard"; } }

        public void DrawPattern(Cell atCell)
        {
            atCell.SetNextIsAlive(true)
                .MarkEastAlive()
                .MarkSouthAlive()
                .East
                .East
                .East
                .MarkEastAlive()
                .MarkEastAlive()
                .MarkEastAlive()
                .NorthWest
                .MarkNorthAlive();
        }
    }
}
