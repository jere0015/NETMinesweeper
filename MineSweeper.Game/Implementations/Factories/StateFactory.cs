using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public class StateFactory : IStateFactory
    {
        public IState Create(IConfig config, IBoard board)
        {
            return new State(board, config);
        }
    }
}
