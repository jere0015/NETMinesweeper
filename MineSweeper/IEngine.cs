using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    interface IEngine
    {
        public int GetInput();

        public Board GetBoard();

        public int GetState();

        public void StartGame(int width, int height);

        public bool IsGameStarted();
    }
}
