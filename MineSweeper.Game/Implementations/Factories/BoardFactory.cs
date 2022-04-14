namespace MineSweeper.Game
{
    public class BoardFactory : IBoardFactory
    {
        public ITileFactory TileFactory { get; }

        public BoardFactory(ITileFactory tileFactory)
        {
            TileFactory = tileFactory;
        }

        public IBoard Create(int width, int height, MineGenerator mineGenerator)
        {
            return new Board(TileFactory, mineGenerator, width, height);
        }
    }
}
