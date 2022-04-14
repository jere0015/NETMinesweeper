namespace MineSweeper.Game
{
    public class State : IState
    {
        public Stage Stage { get; set; } = Stage.Initial;
        public IBoard Board { get; }
        public IConfig Config { get; }

        public State(IBoard board, IConfig config)
        {
            Board = board;

            Config = config;
        }
    }
}
