namespace MineSweeper.Game
{
    public class Tile : ITile
    {
        public IBoard Parent { get; }
        public int X { get; }
        public int Y { get; }
        public bool IsRevealed { get; set; }
        public bool IsMine { get; }

        public Tile(IBoard parent, int x, int y, bool isMine)
        {
            Parent = parent;
            X = x;
            Y = y;
            IsMine = isMine;
            IsRevealed = false;
        }
    }
}
