using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class CellExtensions
    {
        public static Cell MarkNorthAlive(this Cell cell)
        {
            if (cell == null) return null;

            var north = cell.North;

            if(north != null)
            {
                north.SetNextIsAlive(true);
            }

            return north;
        }

        public static Cell MarkSouthAlive(this Cell cell)
        {
            if (cell == null) return null;

            var south = cell.South;

            if (south != null)
            {
                south.SetNextIsAlive(true);
            }

            return south;
        }

        public static Cell MarkEastAlive(this Cell cell)
        {
            if (cell == null) return null;

            var east = cell.East;

            if (east != null)
            {
                east.SetNextIsAlive(true);
            }

            return east;
        }

        public static Cell MarkWestAlive(this Cell cell)
        {
            if (cell == null) return null;

            var west = cell.West;

            if (west != null)
            {
                west.SetNextIsAlive(true);
            }

            return west;
        }

        public static Cell MarkNorthWestAlive(this Cell cell)
        {
            if (cell == null) return null;

            var northwest = cell.NorthWest;

            if (northwest != null)
            {
                northwest.SetNextIsAlive(true);
            }

            return northwest;
        }

        public static Cell MarkSouthWestAlive(this Cell cell)
        {
            if (cell == null) return null;

            var southwest = cell.SouthWest;

            if (southwest != null)
            {
                southwest.SetNextIsAlive(true);
            }

            return southwest;
        }

        public static Cell MarkNorthEastAlive(this Cell cell)
        {
            if (cell == null) return null;

            var northEast = cell.NorthEast;

            if (northEast != null)
            {
                northEast.SetNextIsAlive(true);
            }

            return northEast;
        }

        public static Cell MarkSouthEastAlive(this Cell cell)
        {
            if (cell == null) return null;

            var southEast = cell.SouthEast;

            if (southEast != null)
            {
                southEast.SetNextIsAlive(true);
            }

            return southEast;
        }
    }
}
