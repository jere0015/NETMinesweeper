namespace MineSweeper.Game
{
    /// <summary>
    /// Contract for the Minesweeper game
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Accessor for current state of the game.
        /// </summary>
        public IState? State { get; }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="config"></param>
        /// <returns>Initial gamestate</returns>
        public IState StartGame(IConfig config);

        /// <summary>
        /// Reveal a tile on the board
        /// </summary>
        /// <param name="x">X coordinate of the tile</param>
        /// <param name="y">Y coordinate of the tile</param>
        /// <returns>Updated gamestate</returns>
        public IState RevealTile(int x, int y);
    };
}
