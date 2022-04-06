using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// Defines the different type of input commands the engine accepts
    /// </summary>
    public enum CommandType
    {
        RevealTile,
        
        StartGame,

        EndGame,

        GetState
    }

    /// <summary>
    /// Defines the command message.
    /// A command message holds:
    ///     1) The ID of the command 
    ///     2) The 'body'/data of the command
    /// The ID of the command, tells the user how to interpret the body.
    /// </summary>
    public class Command
    {
        public CommandType type;

        public Dictionary<string, object> Data;
    };
}
