using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Dungeon
{
    static class InputHelper
    {
        public static int GetChoice(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;

                Console.WriteLine($"Enter number between {min} and {max}.");
            }
        }

        public static string GetYesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "yes" || input == "no")
                    return input;
                Console.WriteLine("Type 'yes' or 'no'.");
            }
        }
    }
}
