using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    public class WrongDiceNumberException : Exception
    {
        internal int Number;

        public WrongDiceNumberException(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public WrongDiceNumberException(int number, int min, int max)
            : base($"Invalid dice number: {number}. Allowed range: {min}-{max}") { }

        public int Min { get; }
        public int Max { get; }
    }

    public struct Dice
    {
        private int Min;
        private int Max;

        public int Number
        {
            get
            {
                Random rnd = new();
                return rnd.Next(Min, Max + 1);
            }
        }

        public Dice(int min, int max)
        {
            if (min < 1 || max > int.MaxValue || min > max)
                throw new WrongDiceNumberException(min, 1, int.MaxValue);
            Min = min;
            Max = max;
        }
    }
}
