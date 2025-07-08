using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Equipment
{
    abstract class Equipment : GameItem
    {
        public EquipmentSlot Slot;
        public int Durability;
        public int MaxDurability;

        public void TakeWear()
        {
            Durability--;
            if (Durability <= 0)
                Console.WriteLine($"{Name} broke!");
        }
    }

}
