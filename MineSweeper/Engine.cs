using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Engine : IEngine
    {
        protected IRandomGenerator _random;
        protected GameState _gameState;

        public Engine(IRandomGenerator random)
        {
            _random = random;
        }

        public GameState RunCommand(Command cmd)
        {
            switch (cmd.type)
            {
                case CommandType.StartGame:
                    var width = int.Parse(cmd.Data["width"] as string);
                    var height = int.Parse(cmd.Data["height"] as string);
                    StartGame(width, height);
                    break;

                case CommandType.EndGame:
                    throw new NotImplementedException();

                case CommandType.RevealTile:
                    var x = int.Parse(cmd.Data["x"] as string);
                    var y = int.Parse(cmd.Data["y"] as string);
                    RevealMine(x, y);
                    break;

                case CommandType.GetState:
                    // Just break so gamestate is returned
                    break;

                default:
                    throw new ArgumentException("Invalid command ID");
            }

            return _gameState;
        }

        /// <summary>
        /// Initializes a new board, and sets the game state to 'Ingame'
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void StartGame(int width = 5, int height = 5)
        {
            _gameState = new GameState(_random, width, height);

            _gameState.state = GameState.State.Ingame;
        }

        /// <summary>
        /// Reveals a tile on the board.
        /// Gamestate is updated according to MineSweeper rules
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
                if (_gameState.Board.MineCount == _gameState.Board.RevealedTilesCount)
                {
                    _gameState.state = GameState.State.Won;
                    return;
                }
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

    }
}
