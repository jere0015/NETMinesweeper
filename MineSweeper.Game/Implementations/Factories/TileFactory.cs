namespace MineSweeper.Game
{
    public class TileFactory : ITileFactory
    {
        public ITile Create(IBoard parent, int x, int y, bool isMine)
        {
            return new Tile(parent, x, y, isMine);
        }
    }
}
