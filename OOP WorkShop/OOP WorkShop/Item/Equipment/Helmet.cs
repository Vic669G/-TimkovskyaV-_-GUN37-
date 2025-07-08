using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Equipment
{
    class Helmet : Equipment
    {
        public Helmet(string name)
        {
            Name = name;
            Slot = EquipmentSlot.Helmet;
            MaxDurability = 6;
            Durability = MaxDurability;
        }
    }
}
