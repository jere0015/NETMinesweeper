using Xunit;
using Xunit.Abstractions;

using MineSweeper.Game;

namespace MineSweeper.Test
{
    public class GameTest
    {
        private readonly ITestOutputHelper _logger;

        public GameTest(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        public IGame Instance()
        {
            var stateFactory = new StateFactory();
            var tileFactory = new TileFactory();
            var boardFactory = new BoardFactory(tileFactory);
            var gameFactory = new GameFactory(stateFactory, boardFactory);
            var config = new Config(5, 5, 0, Difficulity.Easy);

            return gameFactory.Create(config);
        }

        [Fact]
        public void CanStartGame()
        {
            var game = Instance();

            Assert.True(game.State.Stage == Stage.Active);
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

            Assert.True(game.State.Stage == Stage.Active);
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
             *     _,X,_,_,_, <- 4,3
             *     _,_,_,_,_, <- 4,4
             *             ^
             *             |
             *            3,4
            */

            game.RevealTile(4, 4);

            Assert.True(game.State.Board.GetTile(4, 3).IsRevealed && game.State.Board.GetTile(3, 4).IsRevealed);
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
                    var tile = game.State.Board.GetTile(x, y);

                    line += tile.IsMine ? "X," : "_,";
                }

                _logger.WriteLine(line);
            }
        }
    }

}
