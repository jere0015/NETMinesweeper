namespace MineSweeper.Game
{
    public class Board : IBoard
    {
        public IEnumerable<ITile> Tiles { get; }

        public int Width { get; }

        public int Height { get; }

        public Board(ITileFactory tileFactory, MineGenerator mineGenerator, int width, int height)
        {
            var tiles = new List<ITile>();
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var isMine = mineGenerator(x, y);

                    tiles.Add(tileFactory.Create(x, y, isMine));
                }
            }

            Tiles = tiles;

            Width = width;

            Height = height;
        }
    }
}
