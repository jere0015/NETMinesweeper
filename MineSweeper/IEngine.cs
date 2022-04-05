using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    interface IEngine
    {
        GameState RunFrame();

        //TODO: Replace RunFrame with this
        GameState RunCommand(Command cmd);
    }
}
