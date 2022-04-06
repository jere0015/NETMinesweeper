using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public interface IEngine
    {
        /// <summary>
        /// Abstract method. Runs a command in the engine.
        /// </summary>
        /// <param name="command">The command to be ran</param>
        /// <returns>The updated gamestate</returns>
        public abstract GameState RunCommand(Command command);

        /// <summary>
        /// Wrapper for the StartGame command
        /// </summary>
        public GameState StartGame(int width, int height)
        {
            return RunCommand(
                new Command
                {
                    type = CommandType.StartGame,
                    Data = new Dictionary<string, object>
                    {
                        { "width", width.ToString() },
                        { "height", height.ToString() }
                    }
                }
            );
        }

        /// <summary>
        /// Wrapper for the RevealTile command
        /// </summary>
        public GameState RevealTile(int x, int y)
        {
            return RunCommand(
                new Command
                {
                    type = CommandType.RevealTile,
                    Data = new Dictionary<string, object>
                    {
                        { "x", x.ToString() },
                        { "y", y.ToString() }
                    }
                }
            );
        }

        /// <summary>
        /// ...
        /// </summary>
        public GameState GetState()
        {
            return RunCommand(
                new Command
                {
                    type = CommandType.GetState,
                }
            );
        }
    }
}
