using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Equipment
{
    class Armour : Equipment
    {
        public int ProtectionPercent;
        public Armour(string name, int protect)
        {
            Name = name;
            Slot = EquipmentSlot.Armour;
            ProtectionPercent = Math.Min(protect, 50);
            MaxDurability = 8;
            Durability = MaxDurability;
        }
    }
}
