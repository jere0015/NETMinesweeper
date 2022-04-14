﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Game
{
    public interface IConfigFactory
    {
        IConfig Create(int boardWidth, int boardHeight, int seed, Difficulity difficulity);
    }
}
