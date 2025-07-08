using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Consumable
{
    class HealthPotion : Consumable
    {
        public HealthPotion()
        {
            Name = "Health Potion";
            Quantity = 1;
            Value = 7;
        }

        public override void Use(Player player)
        {
            player.CurrentHealth = Math.Min(player.MaxHealth, player.CurrentHealth + Value);
            Console.WriteLine($"Healed {Value} HP. Current HP: {player.CurrentHealth}");
        }
    }
}
