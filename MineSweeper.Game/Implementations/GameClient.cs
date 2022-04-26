using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game.Implementations
{

    public interface ICommandFactory
    {
        ICommand Create(CommandType type, params object[] args);
    }

    public enum CommandType
    {
        RevealTile,

        ToggleFlag,
    }

    public abstract class GameClient : IGameClient
    {
        public ICommandFactory CommandFactory { get; set; }
        public IState? State { get; private set; }

        public GameClient(ICommandFactory commandFactory)
        {
            CommandFactory = commandFactory;
        }

        public abstract IState Dispatch(ICommand command);

        public IState StartGame(IConfig config)
        {
            return Dispatch(CommandFactory.Create(CommandType.StartGame, config));
        }
        public IState RevealTile(int x, int y)
        {
            return Dispatch(CommandFactory.Create(CommandType.RevealTile, x, y));
        }

        public IState ToggleFlag(int x, int y)
        {
            return Dispatch(CommandFactory.Create(CommandType.ToggleFlag, x, y));
        }


    }
}
