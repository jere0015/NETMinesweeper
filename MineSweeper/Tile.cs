using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Tile
    {
        public Tile(bool isMine, bool isRevealed = false)
        {
            IsMine = isMine;
            IsRevealed = isRevealed;
        }
        
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
    }
}
