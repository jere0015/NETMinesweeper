using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public class GameFactory : IGameFactory
    {
        public IStateFactory StateFactory { get; }
        public IBoardFactory BoardFactory { get; }

        public GameFactory(IStateFactory stateFactory, IBoardFactory boardFactory)
        {
            StateFactory = stateFactory;
            BoardFactory = boardFactory;
        }

        public IGame Create(IConfig config)
        {
            return new Game(StateFactory, BoardFactory, config);
        }
    }
}
