using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class GameState
    {
        public enum State
        {
            None,
            Ingame,
            Won,
            Lost,
        };

        public State state;

        public GameState(IRandomGenerator random, int width, int height)
        {
            Board = new Board(random);

            Board.Initialize(width, height);
        }

        public Board Board { get; private set; }
        public List<Command> SavedCommands;
    }

    public class Engine : IEngine
    {
        protected IInput _input;
        protected IRandomGenerator _random;
        protected GameState _gameState;

        /// <summary>
        /// Construcotr
        /// </summary>
        public Engine(IInput input, IRandomGenerator random)
        {
            _input = input;
            _random = random;
        }

        private void StartGame(int width = 5, int height = 5)
        {
            _gameState = new GameState(_random, width, height);

            _gameState.state = GameState.State.Ingame;
        }

        private void RevealMine(int x, int y)
        {
            var tile = _gameState.Board.GetTile(x, y);

            tile.IsRevealed = true;

            if (tile.IsMine)
            {
                _gameState.state = GameState.State.Lost;
            }
            else
            {
                return;
                //TODO: Reveal surrounding mines
                //var top_tile = _gameState.Board.GetTile(x, y - 1);
                //var bottom_tile = _gameState.Board.GetTile(x, y + 1);
                //var top_left_tile = _gameState.Board.GetTile(x - 1, y - 1);
                //var top_right_tile = _gameState.Board.GetTile(x - 1, y - 1);
                //var left_tile = _gameState.Board.GetTile(x - 1, y - 1);
                //var right_tile = _gameState.Board.GetTile(x - 1, y - 1);
                //var bottom_left_tile = _gameState.Board.GetTile(x - 1, y - 1);
                //var bottom_top_left_tile = _gameState.Board.GetTile(x - 1, y - 1);
                //
                //if (top_tile.IsMine ||
                //    bottom_tile.IsMine ||
                //    top_left_tile.IsMine ||
                //    top_right_tile.IsMine ||
                //    left_tile.IsMine ||
                //    right_tile.IsMine ||
                //    bottom_left_tile.IsMine ||
                //    bottom_top_left_tile.IsMine)
                //{
                //    top_tile.IsMine = true;
                //    bottom_tile.IsMine = true;
                //    top_right_tile.IsMine = true;
                //    left_tile.IsMine = true;
                //    right_tile.IsMine = true;
                //    bottom_left_tile.IsMine = true;
                //    bottom_top_left_tile.IsMine = true;
                //}
            }
        }


        public GameState RunFrame()
        {
            var cmd = _input.GetNextCommand();

            switch (cmd.type)
            {
                case CommandType.StartGame:
                    var width = int.Parse(cmd.Data["width"] as string);
                    var height = int.Parse(cmd.Data["height"] as string);
                    StartGame(width, height);
                    break;

                case CommandType.EndGame:
                    throw new NotImplementedException();

                case CommandType.DoMove:
                    var x = int.Parse(cmd.Data["x"] as string);
                    var y = int.Parse(cmd.Data["y"] as string);
                    RevealMine(x, y);
                    break;
            }

            return _gameState;
        }

        public GameState RunCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
