using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    /// <summary>
    /// Helper extension for an IBoard object
    /// </summary>
    public static class BoardHelper
    {
        /// <summary>
        /// Get tile by X and Y coordinate
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x">X coordinate of the tile</param>
        /// <param name="y">Y coordinate of the tile</param>
        /// <returns>Tile if valid coordinates, exception if not</returns>
        public static ITile GetTile(this IBoard board, int x, int y)
        {
            return board.Tiles.First(tile => tile.X == x && tile.Y == y);
        }

        /// <summary>
        /// Checks if X and Y are valid board coordinates
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x">X coordinate of the tile</param>
        /// <param name="y">Y coordinate of the tile</param>
        /// <returns>True if valid coordinates</returns>
        public static bool IsValidTileCoordinates(this IBoard board, int x, int y)
        {
            var index = (x * y) + x;

            if (index < 0 || index >= board.Tiles.Count())
                return false;

            return true;
        }
    }
}
