using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameOfLife
{
    public class Cell
    {
        public Point Position { get; private set; }
        public Cell North { get; private set; }
        public Cell NorthEast { get; private set; }
        public Cell NorthWest { get; private set; }
        public Cell South { get; private set; }

        internal Cell SetNextIsAlive(bool v)
        {
            NextIsAlive = true;
            return this;
        }

        public Cell SouthEast { get; private set; }
        public Cell SouthWest { get; private set; }
        public Cell East { get; private set; }
        public Cell West { get; private set; }

        public bool NextIsAlive { get; private set; }
        public bool IsAlive { get; private set; }

        public Cell(int x, int y)
        {
            Position = new Point(x, y);
            countAliveState = (isAliveState) =>
             {
                 var vm = this;
                 var cnt = CountCell(vm.North, isAliveState) +
                           CountCell(vm.NorthEast, isAliveState) +
                           CountCell(vm.NorthWest, isAliveState) +
                           CountCell(vm.South, isAliveState) +
                           CountCell(vm.SouthEast, isAliveState) +
                           CountCell(vm.SouthWest, isAliveState) +
                           CountCell(vm.East, isAliveState) +
                           CountCell(vm.West, isAliveState);

                 return cnt;
             };
        }


        Func<bool, int> countAliveState;

        private int CountCell(Cell cell, bool isAliveState)
        {
            if (cell != null && cell.IsAlive == isAliveState)
            {
                return 1;
            }

            return 0;
        }

        public void CheckRules()
        {
            var liveNeighborCount = countAliveState(true);

            if (IsAlive)
            {
                if (liveNeighborCount < 2)
                {
                    NextIsAlive = false;
                }
                else if( liveNeighborCount == 2 || liveNeighborCount == 3)
                {
                    NextIsAlive = true;
                }
                else if( liveNeighborCount > 3)
                {
                    NextIsAlive = false;
                }
            }
            else if(liveNeighborCount == 3)
            {
                NextIsAlive = true;
            }
            

        }

        public void SwapIsAlive()
        {
            IsAlive = NextIsAlive;
        }

        public void SetNorthernNeighbor(Cell northNeighbor)
        {
            North = northNeighbor;

            if (North != null)
            {
                North.South = this;

                if (North.East != null)
                {
                    NorthEast = North.East;
                    NorthEast.SouthWest = this;
                }

            }

        }

        public void SetWesternNeighbor(Cell neighbor)
        {
            West = neighbor;

            if (West != null)
            {
                neighbor.East = this;

                if (West.North != null)
                {
                    NorthWest = West.North;
                    NorthWest.SouthEast = this;

                    if (NorthWest.East != null)
                    {
                        North = NorthWest.East;
                        North.South = this;
                    }

                    if (North.East != null)
                    {
                        NorthEast = North.East;
                        NorthEast.SouthWest = this;
                    }
                }
            }
        }
    }
}
