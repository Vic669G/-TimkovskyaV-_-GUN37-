using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    public struct Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public int GetPoints()
        {
            int val = (int)Value;
            return val switch
            {
                >= 11 and <= 13 => 10,
                14 => 11,
                _ => val
            };
        }

        public override string ToString() => $"{Value} of {Suit}";
    }
}
