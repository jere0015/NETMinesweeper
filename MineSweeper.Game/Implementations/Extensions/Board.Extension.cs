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
        /// Get tiles neighbourghing a board coordinate set
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>An enumerable of neighbourghing tiles</returns>
        public static IEnumerable<ITile> GetNeighbourghTiles(this IBoard board, int x, int y)
        {
            // Find neighbourghs by comparing X and Y value differences
            var Diff = (int value1, int value2) => Math.Abs(value1 - value2);
            
            // All tiles where difference on X or Y axis is 1 or below 0, and disclude tile at X and Y
            return board.Tiles.Where((tile) => Diff(tile.X, x) <= 1 && Diff(tile.Y, y) <= 1 && !(tile.X == x && tile.Y == y));
        }

        /// <summary>
        /// Get tiles neighbourghing a board coordinate set
        /// </summary>
        /// <param name="tile"></param>
        /// <returns>An enumerable of neighbourghing tiles</returns>
        public static int GetNeighbourghMineCount(this IBoard board, int x, int y)
        {
            return board.GetNeighbourghTiles(x, y).Where(_tile => _tile.IsMine).Count();
        }
    }
}
