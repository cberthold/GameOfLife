using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Patterns
{
    public interface IPattern
    {
        string Name { get; }
        void DrawPattern(Cell atCell);
    }
}
