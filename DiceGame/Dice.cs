using System;

namespace DiceGame
{
    public class Dice : IDice
    {
        private Random Random { get; }
        private int _min = 1;
        private int _max = 6;
        public Dice(Random random)

        {
            Random = random;
        }
        public int Roll()
        {
            return Random.Next(_min, _max);
        }

    }
}
