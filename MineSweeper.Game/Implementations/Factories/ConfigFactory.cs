namespace MineSweeper.Game
{
    public class ConfigFactory : IConfigFactory
    {
        public IConfig Create(int boardWidth, int boardHeight, int seed, Difficulity difficulity)
        {
            return new Config(boardWidth, boardHeight, seed, difficulity);
        }
    }
}
