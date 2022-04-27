namespace MineSweeper.Game
{

    public class Board
    {
        public IEnumerable<Tile> Tiles { get; }
        public int Width { get; }
        public int Height { get; }

        public Board(IEnumerable<Tile> tiles, int width, int height)
        {
            Tiles = tiles;
            Width = width;
            Height = height;
        }
    }

}
