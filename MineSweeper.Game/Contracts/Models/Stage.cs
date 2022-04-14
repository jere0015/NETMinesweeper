namespace MineSweeper.Game
{
    /// <summary>
    /// Enum describing the current stage of the engine.
    /// </summary>
    public enum Stage
    {
        // Start stage
        Initial,

        // The user is currently playing the game
        Active,

        // The user lost the game
        Lost,
    };
}
