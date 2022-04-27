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
        public State State { get; }

        /// <summary>
        /// Reveal a tile on the board
        /// </summary>
        /// <param name="x">X coordinate of the tile</param>
        /// <param name="y">Y coordinate of the tile</param>
        /// <returns>Updated gamestate</returns>
        public void RevealTile(int x, int y);

        /// <summary>
        /// Toggles a flag on and off on a tile on the board
        /// </summary>
        /// <param name="x">X coordinate of the tile</param>
        /// <param name="y">Y coordinate of the tile</param>
        /// <returns>Updated gamestate</returns>
        public void ToggleFlag(int x, int y);
    };
}
