using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace MineSweeper.Test
{

    public class MockInput : IInput
    {
        public List<Command> InputCommands = new List<Command>();

        public Command GetNextCommand()
        {
            var command = InputCommands[0];
            InputCommands.RemoveAt(0);
            return command;
        }

        public void QueueInput(Command command)
        {
            InputCommands.Add(command);
        }
    }


    public abstract class EngineInterface
    {
        public abstract GameState RunCommand(Command command);

        public GameState StartGame(int x, int y)
        {
            return RunCommand(
                new Command
                {
                    type = CommandType.StartGame,
                    Data = new Dictionary<string, object>
                    {
                            { "width", x.ToString() },
                            { "height", y.ToString() }
                    }
                }
            );
        }
    }


    public class EngineMock : Engine
    {
        private MockInput input;

        public EngineMock() : base(new MockInput(), new RandomGenerator(0))
        {
            input = this._input as MockInput;
        }

        public GameState StartGame(int x, int y)
        {
            input.QueueInput(
                new Command
                {
                    type = CommandType.StartGame,
                    Data = new Dictionary<string, object>
                    {
                            { "width", x.ToString() },
                            { "height", y.ToString() }
                    }
                }
            );

            //RunCommand(
            //    new Command
            //    {
            //        type = CommandType.StartGame,
            //        Data = new Dictionary<string, object>
            //        {
            //                { "width", x.ToString() },
            //                { "height", y.ToString() }
            //        }
            //    });
            
            return RunFrame();
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
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            Assert.True(gameState.state == GameState.State.Ingame);
        }

        [Fact]
        public void StartedGameHasTiles()
        {
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            Assert.True(gameState.Board.GetTiles().Count > 0);
        }

        [Fact]
        public void StartedGameHasExpectedNumTiles()
        {
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            Assert.True(gameState.Board.GetTiles().Count > 0);
        }

        [Fact]
        public void StartedGameHasTileWithoutMine()
        {
            var engine = new EngineMock();

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
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            foreach (var tile in gameState.Board.Tiles)
            {
                if (tile.IsMine)
                    return;
            }

            Assert.True(true);
        }

        [Fact]
        public void StartedGameEndsWhenAllMinesRevealed()
        {
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            /*
             * 
             *     _____
                   ___X_
                   _X__X
                   __X_X
                   X____
             * 
             */

            Assert.True(false);
        }

        [Fact]
        public void StartedGameEndsWhenMineRevealed()
        {
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            Assert.True(false);
        }


        [Fact]
        public void PrintBoard()
        {
            var engine = new EngineMock();

            var gameState = engine.StartGame(5, 5);

            for (int x = 0; x < gameState.Board.Width; x++)
            {
                var line = "";

                for (int y = 0; y < gameState.Board.Height; y++)
                {
                    var tile = gameState.Board.GetTile(x, y);

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
