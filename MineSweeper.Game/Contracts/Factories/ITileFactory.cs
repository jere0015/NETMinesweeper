namespace MineSweeper.Game
{
    public interface ITileFactory
    {
        public ITile Create(int x, int y, bool isMine);
    }
}
