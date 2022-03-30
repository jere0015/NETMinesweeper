using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace MineSweeper.Test
{
    public class MockInput : IInput
    {
        private List<int> moves;

        public MockInput()
        {
            moves = new List<int>();
        }
        public int GetMove()
        {
            throw new NotImplementedException();
        }
    }

    public class EngineTest
    {
        private readonly ITestOutputHelper _logger;

        public EngineTest(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Fact]
        public void CanStartGame()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame();

            Assert.True(engine.IsGameStarted());
        }

        [Fact]
        public void StartedGameHasTiles()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame();

            Assert.True(engine.Board.GetTiles().Count > 0);
        }

        [Fact]
        public void StartedGameHasExpectedNumTiles()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame(5 * 5);

            Assert.True(engine.Board.GetTiles().Count > 0);
        }

        [Fact]
        public void StartedGameHasTileWithoutMine()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame();

            foreach (var tile in engine.GetBoard().Tiles)
            {
                if (!tile.IsMine)
                    return;
            }

            Assert.True(false);
        }

        [Fact]
        public void StartedGameHasTileWithMine()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame();

            foreach (var tile in engine.GetBoard().Tiles)
            {
                if (tile.IsMine)
                    return;
            }

            Assert.True(true);
        }

        [Fact]
        public void StartedGameEndsWhenAllMinesRevealed()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            /*
             * 
             *     _____
                   ___X_
                   _X__X
                   __X_X
                   X____
             * 
             */

            engine.StartGame();

            Assert.True(false);
        }

        [Fact]
        public void StartedGameEndsWhenMineRevealed()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame();

            Assert.True(false);
        }


        [Fact]
        public void PrintBoard()
        {
            var engine = new Engine(new MockInput(), new RandomGenerator(0));

            engine.StartGame();

            for (int x = 0; x < engine.Board.Width; x++)
            {
                var line = "";

                for (int y = 0; y < engine.Board.Height; y++)
                {
                    var tile = engine.Board.GetTile(x, y);

                    line += tile.IsMine ? "X" : "_";
                }

                _logger.WriteLine(line);

            }
        }

    }

    public class BoardTest
    {
        public BoardTest()
        {
        }

        [Fact]
        public void GameLostWhenMineInteracted()
        {
            var board = new Board(new RandomGenerator(0));
        }


        [Fact]
        public void GameWonWhenAllMinesRevealed()
        {

        }


        [Fact]
        public void AdjectantEmptyTilesRevealedOnReveal()
        {

        }


        [Fact]
        public void IsUnableToRevealFlaggedTile()
        {

        }
    }
}
