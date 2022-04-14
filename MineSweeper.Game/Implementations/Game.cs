namespace MineSweeper.Game
{
    public class Game : IGame
    {
        public IState State { get; }
        public IConfig Config { get; }

        public Game(IStateFactory stateFactory, IBoardFactory boardFactory, IConfig config)
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

            if (tile.IsRevealed == false)
            {
                tile.IsRevealed = true;

                if (tile.IsMine)
                {
                    State.Stage = Stage.Lost;
                }
                else
                {
                    // If any neighbourgh is not a mine
                    if (tile.Neighbourghs().Any((tile) => tile.IsMine) == false)
                    {
                        // Reveal all unrevealed neighbourghs
                        tile.Neighbourghs().ToList().ForEach(_tile =>
                        {
                            if (_tile.IsRevealed is false)
                            {
                                RevealTile(_tile.X, _tile.Y);
                            }
                        });
                    }
                }

                if(State.Board.Tiles.Where(tile => !tile.IsRevealed && !tile.IsMine).Count() == 0)
                {
                    State.Stage = Stage.Won;
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

            return random.Next(0, 4) == 0;
        }
    }
}
