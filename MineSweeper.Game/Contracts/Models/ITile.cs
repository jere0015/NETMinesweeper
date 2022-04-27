using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    /// <summary>
    /// Describes a single tile on a MineSweeper board
    /// </summary>
    public interface ITile
    {
        /// <summary>
        /// The X coordinate of the tile
        /// </summary>
        public int X { get; }

        /// <summary>
        /// The Y coordinate of the tile
        /// </summary>
        public int Y { get; }
        
        /// <summary>
        /// Tells whether this tile has a mine or not
        /// </summary>
        public bool IsMine { get; }

        /// <summary>
        /// Tells whether this tile has been revealed
        /// </summary>
        public bool IsRevealed { get; set; }

        /// <summary>
        /// Tells whether this tile has a flag on it
        /// </summary>
        public bool IsFlagged { get; set; }
    }
}
