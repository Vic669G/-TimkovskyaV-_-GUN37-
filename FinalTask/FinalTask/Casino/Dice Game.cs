using FinalTask.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Casino
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _count;
        private readonly int _min;
        private readonly int _max;
        private List<WrongDiceNumberException> _dices;

        public DiceGame(int count, int min, int max)
        {
            if (count <= 0)
                throw new ArgumentException("Dice count must be positive.");
            _count = count;
            _min = min;
            _max = max;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _dices = new List<WrongDiceNumberException>();
            for (int i = 0; i < _count; i++)
                _dices.Add(new WrongDiceNumberException(_min, _max));
        }

        public override void PlayGame()
        {
            int player = _dices.Sum(d => d.Number);
            int dealer = _dices.Sum(d => d.Number);

            Console.WriteLine($"You rolled: {player} | Dealer rolled: {dealer}");

            if (player > dealer)
                OnWinInvoke();
            else if (player < dealer)
                OnLooseInvoke();
            else
                OnDrawInvoke();
        }
    }
}
