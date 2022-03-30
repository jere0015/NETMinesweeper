using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Command
    {
        bool isMoveCommand;
        bool isRestartCommand;

    };

    public interface IInput
    {
        int GetMove();

        Command GetCommand();
    }
}
