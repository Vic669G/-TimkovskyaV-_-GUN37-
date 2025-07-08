using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Consumable
{
    class Whetstone : Consumable
    {
        public Whetstone()
        {
            Name = "Whetstone";
            Quantity = 1;
            Value = 4;
        }

        public override void Use(Player player)
        {
            foreach (var eq in player.EquipmentSlots.Values)
            {
                eq.Durability = Math.Min(eq.MaxDurability, eq.Durability + Value);
            }
        }
    }

}
