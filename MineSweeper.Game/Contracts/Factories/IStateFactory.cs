using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public interface IStateFactory
    {
        IState Create(IConfig config, IBoard board);
    }

}
