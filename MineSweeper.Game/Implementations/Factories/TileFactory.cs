namespace MineSweeper.Game
{
    public class TileFactory : ITileFactory
    {
        public ITile Create(int x, int y, bool isMine)
        {
            return new Tile(x, y, isMine);
        }
    }
}
