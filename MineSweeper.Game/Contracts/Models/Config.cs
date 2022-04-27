namespace MineSweeper.Game
{

    public class Config
    {
        public int BoardWidth { get; }
        public int BoardHeight { get; }
        public int Seed { get; }
        public Difficulity Difficulity { get; }

        public Config(int boardWidth, int boardHeight, int seed, Difficulity difficulity)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            Seed = seed;
            Difficulity = difficulity;
        }
    }
}
