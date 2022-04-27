namespace MineSweeper.Game
{
    public class Tile : ITile
    {
        public int X { get; }
        public int Y { get; }
        public bool IsRevealed { get; set; }
        public bool IsMine { get; }
        public bool IsFlagged { get; set; }

        public Tile(int x, int y, bool isMine)
        {
            X = x;
            Y = y;
            IsMine = isMine;
            IsRevealed = false;
            IsFlagged = false;
        }
    }
}
