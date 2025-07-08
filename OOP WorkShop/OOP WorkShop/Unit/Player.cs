using OOP_WorkShop.Dungeon;
using OOP_WorkShop.Item.Consumable;
using OOP_WorkShop.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Unit
{
    class Player : Units
    {
        public override void Attack(Units target)
        {
            int totalDamage = BaseDamage;
            if (EquipmentSlots.ContainsKey(EquipmentSlot.Weapon))
                totalDamage += ((Weapon)EquipmentSlots[EquipmentSlot.Weapon]).Damage;

            Console.WriteLine($"{Name} attacks {target.Name} for {totalDamage} damage!");
            target.TakeDamage(totalDamage);
        }

        public void EquipItem(Equipment item)
        {
            if (EquipmentSlots.ContainsKey(item.Slot))
            {
                Console.WriteLine($"Replace {EquipmentSlots[item.Slot].Name} with {item.Name}? (yes/no)");
                if (InputHelper.GetYesOrNo() == "yes")
                    EquipmentSlots[item.Slot] = item;
            }
            else
            {
                EquipmentSlots[item.Slot] = item;
                Console.WriteLine($"Equipped {item.Name}.");
            }
        }

        public void RepairEquipment()
        {
            foreach (var item in Inventory)
            {
                if (item is Whetstone stone && stone.Quantity > 0)
                {
                    stone.Use(this);
                    stone.Quantity--;
                    Console.WriteLine("Used Whetstone to repair equipment.");
                    return;
                }
            }
            Console.WriteLine("No Whetstone found!");
        }
    }
}
