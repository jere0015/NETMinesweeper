using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class RandomGenerator : IRandomGenerator
    {
        private Random random;
        public int Seed { get; }

        public RandomGenerator(int seed)
        {
            Seed = seed;
            random = new Random(seed);
        }

        public int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        public bool RandomBool()
        {
            return random.Next(0, 2) == 0;
        }
    }
}
