using FinalTask.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Casino
{
    public class Blackjack : CasinoGameBase
    {
        private readonly int _numberOfCards;
        private readonly List<Card> _deck = new();
        private Queue<Card> DeckQueue;

        public Blackjack(int numberOfCards)
        {
            if (numberOfCards < 4)
                throw new ArgumentException("Not enough cards to play.");
            _numberOfCards = numberOfCards;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _deck.Clear();
            Array suits = Enum.GetValues(typeof(CardSuit));
            Array values = Enum.GetValues(typeof(CardValue));
            Random rnd = new();

            while (_deck.Count < _numberOfCards)
            {
                var suit = (CardSuit)suits.GetValue(rnd.Next(suits.Length));
                var val = (CardValue)values.GetValue(rnd.Next(values.Length));
                var card = new Card(suit, val);
                _deck.Add(card);
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random rnd = new();
            DeckQueue = new Queue<Card>(_deck.OrderBy(_ => rnd.Next()));
        }

        public override void PlayGame()
        {
            List<Card> player = [DeckQueue.Dequeue(), DeckQueue.Dequeue()];
            List<Card> dealer = [DeckQueue.Dequeue(), DeckQueue.Dequeue()];

            Console.WriteLine("Your cards:");
            player.ForEach(c => Console.WriteLine(c));
            int playerPoints = player.Sum(c => c.GetPoints());

            Console.WriteLine("\nDealer's cards:");
            dealer.ForEach(c => Console.WriteLine(c));
            int dealerPoints = dealer.Sum(c => c.GetPoints());

            CompareHands(playerPoints, dealerPoints);
        }

        private void CompareHands(int player, int dealer)
        {
            while (player == dealer && player < 21)
            {
                player += DeckQueue.Dequeue().GetPoints();
                dealer += DeckQueue.Dequeue().GetPoints();
            }

            Console.WriteLine($"\nFinal Score - You: {player} | Dealer: {dealer}");

            if (player > 21 && dealer > 21)
                OnDrawInvoke();
            else if (player <= 21 && (dealer > 21 || player > dealer))
                OnWinInvoke();
            else if (dealer <= 21 && (player > 21 || dealer > player))
                OnLooseInvoke();
            else
                OnDrawInvoke();
        }
    }
}
