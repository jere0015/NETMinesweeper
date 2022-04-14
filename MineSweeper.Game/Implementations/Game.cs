﻿namespace MineSweeper.Game
{
    /// <summary>
    /// Implementation for the Minesweeper game
    /// </summary>
    public class Game : IGame
    {
        public IState State { get; }
        public IConfig Config { get; }

        public Game(IStateFactory stateFactory, IBoardFactory boardFactory,  IConfig config)
        {
            Config = config;

            var board = boardFactory.Create(config.BoardWidth, config.BoardHeight, IsMine);

            var state = stateFactory.Create(config, board);

            State = state;

            State.Stage = Stage.Active;
        }
 
        public IState RevealTile(int x, int y)
        {
            if (State.Stage != Stage.Active)
            {
                throw new InvalidOperationException();
            }

            var tile = State.Board.GetTile(x, y);

            tile.IsRevealed = true;

            if (tile.IsMine)
            {
                State.Stage = Stage.Lost;
            }
            else
            {
                if (tile.HasNeighbourghingMine() == false)
                {
                    foreach (var neighbourgh in tile.Neighbourghs())
                    {
                        if (neighbourgh.IsRevealed == false)
                        {
                            RevealTile(neighbourgh.X, neighbourgh.Y);
                        }
                    }
                }
            }

            return State;
        }

        /// <summary>
        /// Checks if X and Y coordinate is supposed to contain a mine, depending on RNG seed
        /// </summary>
        /// <param name="x">X board coordinate</param>
        /// <param name="y">Y board coordinate</param>
        /// <returns>True if supposed to have a mine, false if not</returns>
        private bool IsMine(int x, int y)
        {
            // Base RNG of Seed + X coordinate + Y coordinate
            var random = new Random(Config.Seed + ((x + 0x5c4931ea) * (x + 1)) * (y + 0x7f29e92c) * (y + 1));

            return random.Next(0, 2) == 0;
        }
    }
}