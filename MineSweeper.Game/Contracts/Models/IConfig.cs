namespace MineSweeper.Game
{
    /// <summary>
    /// Configuration for a Minesweeper game
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// The width of the board
        /// </summary>
        public int BoardWidth { get; }
        
        /// <summary>
        /// The height of the board
        /// </summary>
        public int BoardHeight { get; }
        
        /// <summary>
        /// The seed randomness is based of
        /// </summary>
        public int Seed { get; }

        /// <summary>
        /// The difficulity of the game. Decides the mine density
        /// </summary>
        public Difficulity Difficulity { get; }
    }
}
