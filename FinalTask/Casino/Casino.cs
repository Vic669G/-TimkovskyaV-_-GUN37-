using FinalTask.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Casino
{
    public class Casino : IGame
    {
        private readonly Player _player;
        private readonly ISaveLoadService<Player> _saveService;

        public Casino(Player player, ISaveLoadService<Player> saveService)
        {
            _player = player;
            _saveService = saveService;
        }

        public void StartGame()
        {
            while (true)
            {
                if (_player.Bank <= 0)
                {
                    Console.WriteLine("No money? Kicked!");
                    return;
                }

                Console.WriteLine("\nChoose a game: 1 - Blackjack, 2 - DiceGame, 0 - Exit");
                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                Console.Write("Enter your bet: ");
                if (!int.TryParse(Console.ReadLine(), out int bet) || bet <= 0 || bet > _player.Bank)
                {
                    Console.WriteLine("Invalid bet.");
                    continue;
                }

                CasinoGameBase game = choice switch
                {
                    "1" => new Blackjack(20),
                    "2" => new DiceGame(2, 1, 6),
                    _ => null
                };

                if (game == null)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                game.OnWin += () =>
                {
                    _player.Bank += bet;
                    Console.WriteLine($"You win! +{bet} | Bank: {_player.Bank}");
                };
                game.OnLoose += () =>
                {
                    _player.Bank -= bet;
                    Console.WriteLine($"You lost! -{bet} | Bank: {_player.Bank}");
                };
                game.OnDraw += () =>
                {
                    Console.WriteLine($"Draw! Bet returned. | Bank: {_player.Bank}");
                };

                game.PlayGame();

                if (_player.Bank > int.MaxValue)
                {
                    _player.Bank = int.MaxValue;
                    Console.WriteLine("You broke the bank! Casino closed!");
                }
                else if (_player.Bank > 1_000_000)
                {
                    _player.Bank /= 2;
                    Console.WriteLine("You wasted half of your bank money in casino’s bar.");
                }
            }

            _saveService.SaveData(_player, _player.Name);
            Console.WriteLine("Game saved. Goodbye!");
        }
    }
}
