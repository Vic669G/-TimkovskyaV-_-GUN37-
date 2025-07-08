using OOP_WorkShop.Dungeon;
using OOP_WorkShop.Item.Equipment;
using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_WorkShop.Attack
{
    class Battle
    {
        public static void Start(Player player, Units enemy)
        {
            Console.WriteLine($"A wild {enemy.Name} appears!");
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                Console.WriteLine("\nChoose: 1-Rock  2-Paper  3-Scissors");
                int pChoice = InputHelper.GetChoice(1, 3);
                int eChoice = Random.Shared.Next(1, 4);

                Console.WriteLine($"Enemy chose {(eChoice == 1 ? "Rock" : eChoice == 2 ? "Paper" : "Scissors")}");

                if (pChoice == eChoice)
                {
                    Console.WriteLine("Draw!");
                }
                else if ((pChoice == 1 && eChoice == 3) || (pChoice == 2 && eChoice == 1) || (pChoice == 3 && eChoice == 2))
                {
                    player.Attack(enemy);
                }
                else
                {
                    int raw = enemy.BaseDamage;
                    int reduction = player.EquipmentSlots.ContainsKey(EquipmentSlot.Armour)
                        ? ((Armour)player.EquipmentSlots[EquipmentSlot.Armour]).ProtectionPercent : 0;

                    int damage = raw * (100 - reduction) / 100;
                    enemy.Attack(player);
                    Console.WriteLine($"Damage reduced to {damage}");
                    player.TakeDamage(damage);
                }
            }

            if (player.CurrentHealth <= 0)
                Console.WriteLine("You died!");
            else
                Console.WriteLine($"Defeated {enemy.Name}!");
        }
    }
}
