using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Engine : IEngine
    {
        private bool isGameStarted;

        public Board Board { get; private set; }
        public IInput Input { get; private set; }

        /// <summary>
        /// Construcotr
        /// </summary>
        public Engine(IInput input, IRandomGenerator random)
        {
            Input = input;
            isGameStarted = false;
            Board = new Board(random);
        }
        
        public Board GetBoard()
        {
            return Board;
        }

        public int GetInput()
        {
            throw new NotImplementedException();
        }

        public int GetState()
        {
            throw new NotImplementedException();
        }

        public bool IsGameStarted()
        {
            return this.isGameStarted;
        }

        public void StartGame(int width = 5, int height = 5)
        {
            this.Board.Initialize(width, height);

            this.isGameStarted = true;
        }

        public void RunGame()
        {
            while (gamaeIsRunning)
            {
                var move = Input.GetMove();

                move.x
                move.y;

                var tile = Board.GetTile(move.x, move.y);

                if(tile.IsMine)
                {
                    isGameEnded = false;
                }
                else
                {
                    // TODO: Hvis alle tiles rundt om tilet/feltet ikke indeholder miner - reveal dem
                    tile.IsRevealed = true;

                    if(move.x - 1 >= 0)
                    {
                        var tileLeft = Board.GetTile(move.x - 1, move.y);

                        if(!tileLeft.IsMine)
                        {
                            tileLeft.IsRevealed = true;
                        }
                    }
                }
            }
        }

        Board IEngine.GetBoard()
        {
            throw new NotImplementedException();
        }

        int IEngine.GetInput()
        {
            throw new NotImplementedException();
        }

        int IEngine.GetState()
        {
            throw new NotImplementedException();
        }
    }
}
