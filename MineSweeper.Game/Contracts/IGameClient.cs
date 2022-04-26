namespace MineSweeper.Game
{
    public interface IGameClient : IGame
    {
        /// <summary>
        /// Dispatch a command to the server
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Updated state</returns>
        IState Dispatch(ICommand command);
    }
}
