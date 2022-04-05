using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public enum CommandType
    {
        DoMove,
        
        StartGame,
        // args: width, height

        EndGame
    }

    public class Command
    {
        public CommandType type;

        public Dictionary<string, object> Data;
    };

    public interface IInput
    {
        // Get next input for execution
        Command GetNextCommand();
    }
}
