namespace MineSweeper.Game
{
    /// <summary>
    /// Enum describing the current stage of the engine.
    /// </summary>
    public enum Stage
    {
        // The user is currently playing the game
        Playing,

        // The user lost the game
        Lost,

        Won,
    }
}
