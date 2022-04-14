using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    /// <summary>
    /// Delegate that tells whether or not tile at position X and Y should be a mine
    /// </summary>
    /// <param name="x">X coordinate of the tile</param>
    /// <param name="y">Y coordinate of the tile</param>
    /// <returns>True if it should be a mine, false if not</returns>
    public delegate bool MineGenerator(int x, int y);
}
