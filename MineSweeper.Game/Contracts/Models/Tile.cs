namespace MineSweeper.Game
{
    public class Tile
    {
        public int X { get; }
        public int Y { get; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }

        public Tile(int x, int y, bool isMine)
        {
            X = x;
            Y = y;
            IsMine = isMine;
            IsRevealed = false;
            IsFlagged = false;
        }

        public IEnumerable<Tile> Neighbourghs(Board parent)
        {
            var Diff = (int value1, int value2) => Math.Abs(value1 - value2);

            return parent.Tiles.Where((tile) => Diff(tile.X, X) <= 1 && Diff(tile.Y, Y) <= 1 && !(tile.X == X && tile.Y == Y));
        }
    }
}
