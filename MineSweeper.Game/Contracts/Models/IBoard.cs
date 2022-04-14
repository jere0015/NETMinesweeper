namespace MineSweeper.Game
{
    /// <summary>
    /// Object describing the MineSweeper board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// The tiles on the board
        /// </summary>
        public IEnumerable<ITile> Tiles { get; }

        /// <summary>
        /// The width of the board
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The height of the board
        /// </summary>
        public int Height { get; }
    }
}
