using Xunit;
using Xunit.Abstractions;

namespace MineSweeper.Game.Test
{
    public class GameTest
    {
        private readonly ITestOutputHelper _logger;
        private readonly Config _config;

        public GameTest(ITestOutputHelper logger)
        {
            _logger = logger;

            _config = new Config(5, 5, 0, Difficulity.Easy);
        }

        public IGame Instance()
        {
            var game = new Game(_config);

            return game;
        }

        [Fact]
        public void CanStartGame()
        {
            var game = Instance();

            Assert.True(game.State.Stage == Stage.Playing);
        }


        [Fact]
        public void GameHasTiles()
        {
            var game = Instance();

            Assert.True(game.State.Board.Tiles.Count() > 0);
        }


        [Fact]
        public void GameHasExpectedNumTiles()
        {
            var game = Instance();

            Assert.True(game.State.Board.Tiles.Count() == game.State.Config.BoardWidth * game.State.Config.BoardHeight);
        }

        [Fact]
        public void GameHasMines()
        {
            var game = Instance();

            Assert.True(game.State.Board.Tiles.FirstOrDefault((tile) => tile.IsMine) != null);
        }


        [Fact]
        public void GameHasNonMines()
        {
            var game = Instance();

            Assert.True(game.State.Board.Tiles.FirstOrDefault((tile) => !tile.IsMine) != null);
        }

        [Fact]
        public void CanRevealTile()
        {
            var game = Instance();

            game.RevealTile(0, 0);

            Assert.True(game.State.Board.Tiles.ElementAt(0).IsRevealed);
        }

        [Fact]
        public void GameLostWhenMineRevealed()
        {
            var game = Instance();

            var mineTile = game.State.Board.Tiles.First((tile) => tile.IsMine);

            game.RevealTile(mineTile.X, mineTile.Y);

            Assert.True(game.State.Stage == Stage.Lost);
        }

        [Fact]
        public void GameContinuesWhenNonMineRevealed()
        {
            var game = Instance();

            var nonMineTile = game.State.Board.Tiles.First((tile) => !tile.IsMine);

            game.RevealTile(nonMineTile.X, nonMineTile.Y);

            Assert.True(game.State.Stage == Stage.Playing);
        }

        [Fact]
        public void MinesRevealRecursivly()
        {
            var game = Instance();

            /*
             * Test expects this board:
             * 
             *     X,_,_,_,_,
             *     _,_,X,_,X,
             *     _,_,_,X,_,
             *     _,X,_,_,_,
             *     _,_,_,_,_,
             *     
            */

            game.RevealTile(4, 4);

            // After revealing expect the 6 cells in the cornor to be revealed
            var coordinates = new List<(int, int)>()
            {
               (4, 3), (3, 4), (4, 2), (3, 2)
            };

            coordinates.ForEach(coordinateSet =>
            {
                (int x, int y) = coordinateSet;

                Assert.True(game.State.Board.Tiles.First(_ => _.X == x && _.Y == y).IsRevealed, $"{x} {y} Failed");
            });
        }

        [Fact]
        public void PrintBoard()
        {
            var game = Instance();

            for (int x = 0; x < game.State.Board.Width; x++)
            {
                var line = "";

                for (int y = 0; y < game.State.Board.Height; y++)
                {
                    var tile = game.State.Board.Tiles.First(_ => _.X == x && _.Y == y);

                    line += tile.IsMine ? "X," : "_,";
                }

                _logger.WriteLine(line);
            }
        }
    }

}
