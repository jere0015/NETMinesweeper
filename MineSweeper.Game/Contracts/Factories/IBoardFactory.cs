namespace MineSweeper.Game
{
    public interface IBoardFactory
    {
        public IBoard Create(int width, int height, MineGenerator mineGenerator);
    }
}
