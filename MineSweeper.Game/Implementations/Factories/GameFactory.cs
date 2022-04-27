using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public class GameFactory : IGameFactory
    {
        public IGame Create()
        {
            return new Game();
        }

        public IGame Create(Config config)
        {
            return new Game(config);
        }
    }
}
