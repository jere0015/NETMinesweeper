using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace MineSweeper.Test
{
    public class EngineTest
    {
        private readonly ITestOutputHelper _logger;

        public EngineTest(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        public IEngine CreateEngine()
        {
            return new Engine(new RandomGenerator(0));
        }

        [Fact]
        public void CanStartGame()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            Assert.True(gameState.state == GameState.State.Ingame);
        }


        [Fact]
        public void StartedGameHasTiles()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            Assert.True(gameState.Board.GetTiles().Count > 0);
        }

        [Fact]
        public void StartedGameHasExpectedNumTiles()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            Assert.True(gameState.Board.GetTiles().Count == 25);
        }

        [Fact]
        public void StartedGameHasTileWithoutMine()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            foreach (var tile in gameState.Board.Tiles)
            {
                if (!tile.IsMine)
                    return;
            }

            Assert.True(false);
        }

        [Fact]
        public void StartedGameHasTileWithMine()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            foreach (var tile in gameState.Board.Tiles)
            {
                if (tile.IsMine)
                    return;
            }

            Assert.True(true);
        }

        [Fact]
        public void StartedGameWonWhenAllNonMinesRevealed()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            for (int x = 0; x < gameState.Board.Width; x++)
            {
                for (int y = 0; y < gameState.Board.Height; y++)
                {
                    if (!gameState.Board.GetTile(x, y).IsMine)
                    {
                        gameState = engine.RevealTile(x, y);
                    }
                }
            }

            Assert.True(gameState.state == GameState.State.Won);
        }

        [Fact]
        public void StartedGameLostWhenMineRevealed()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            for (int x = 0; x < gameState.Board.Width; x++)
            {
                for (int y = 0; y < gameState.Board.Height; y++)
                {
                    if (gameState.Board.GetTile(x, y).IsMine)
                    {
                        gameState = engine.RevealTile(x, y);

                        Assert.True(gameState.state == GameState.State.Lost);

                        return;
                    }
                }
            }
            Assert.True(false);
        }


        /// <summary>
        /// Not a real test, just used to visualize the board
        /// </summary>
        [Fact]
        public void PrintRevealedBoard()
        {
            var engine = CreateEngine();

            var gameState = engine.StartGame(5, 5);

            for (int x = 0; x < gameState.Board.Width; x++)
            {
                var line = "";

                for (int y = 0; y < gameState.Board.Height; y++)
                {
                    var tile = gameState.Board.GetTile(x, y);

                    line += tile.IsMine ? "X," : "_,";
                }

                _logger.WriteLine(line);
            }
        }
    }
}
