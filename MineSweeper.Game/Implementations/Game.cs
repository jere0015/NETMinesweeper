namespace MineSweeper.Game
{
    public class Game : IGame
    {
        public State State { get; set; }

        public Game()
        {
            var defaultConfig = new Config(10, 10, (int)DateTime.Now.Ticks, Difficulity.Easy);

            State = CreateState(defaultConfig);
        }

        public Game(Config config)
        {
            State = CreateState(config);
        }
        public Game(State state)
        {
            State = state;
        }

        public void RevealTile(int x, int y)
        {
            var tile = State.Board.Tiles.First(_ => _.X == x && _.Y == y);

            if (!tile.IsRevealed)
            {
                tile.IsRevealed = true;

                foreach (var neighbourgh in tile.Neighbourghs(State.Board))
                {
                    if (neighbourgh.Neighbourghs(State.Board).Any(_ => _.IsMine) is false)
                    {
                        neighbourgh.Neighbourghs(State.Board).ToList().ForEach(_ => RevealTile(_.X, _.Y));
                    }

                }
                UpdateStage();
            }
        }

        public void ToggleFlag(int x, int y)
        {
            var tile = State.Board.Tiles.First(_ => _.X == x && _.Y == y);

            if (!tile.IsRevealed)
            {
                tile.IsFlagged = !tile.IsFlagged;

                UpdateStage();
            }
        }


        private void UpdateStage()
        {
            // Loss condition
            if (State.Board.Tiles.Any(_ => _.IsRevealed && _.IsMine))
            {
                State.Stage = Stage.Lost;

                return;
            }

            // Win condition
            if (State.Board.Tiles.All(_ => (_.IsRevealed || _.IsFlagged)))
            {
                State.Stage = Stage.Won;
                
                return;
            }
        }

        private static bool RollMine(int x, int y, int seed)
        {
            // Base RNG of Seed + X coordinate + Y coordinate
            var random = new Random(seed + ((x + 0x5c4931ea) * (x + 1)) * (y + 0x7f29e92c) * (y + 1));

            return random.Next(0, 4) == 0;
        }

        private static State CreateState(Config config)
        {
            var tiles = new List<Tile>();

            for (int x = 0; x < config.BoardWidth; x++)
            {
                for (int y = 0; y < config.BoardHeight; y++)
                {
                    tiles.Add(new Tile(x, y, RollMine(x, y, config.Seed)));
                }
            }

            var board = new Board(tiles, config.BoardWidth, config.BoardHeight);

            return new State(Stage.Playing, board, config);
        }
    }
}
