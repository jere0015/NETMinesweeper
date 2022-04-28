namespace MineSweeper.Game
{

    public class State
    {
        public Stage Stage { get; set; }

        public Board Board { get; }

        public Config Config { get; }

        public State(Stage stage, Board board, Config config)
        {
            Stage = stage;
            Config = config;
            Board = board;
        }
    }
}
