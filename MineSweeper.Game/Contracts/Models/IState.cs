namespace MineSweeper.Game
{
    /// <summary>
    /// Object describing the current state of a game session
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// The current stage we're in
        /// </summary>
        public Stage Stage { get; set; }

        /// <summary>
        /// The board state
        /// </summary>
        public IBoard Board { get; }

        /// <summary>
        /// The configuration the game was started with
        /// </summary>
        public IConfig Config { get; }
    }
}
