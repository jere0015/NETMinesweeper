using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public interface IRandomGenerator
    {
        int RandomInt(int min, int max);

        bool RandomBool();
    }
}
