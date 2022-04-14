namespace MineSweeper.Game
{
    public interface ITileFactory
    {
        public ITile Create(IBoard parent, int x, int y, bool isMine);
    }
}
