using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game.Contracts
{
    public interface IGameServer
    {
        /// <summary>
        /// Dispatch a command to the engine
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        IState Dispatch(ICommand command);
    }
}
