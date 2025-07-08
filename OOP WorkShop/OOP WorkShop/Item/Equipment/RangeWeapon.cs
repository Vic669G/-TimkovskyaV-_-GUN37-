using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Equipment
{
    class RangeWeapon : Equipment
    {
        public int BonusDamage;
        public RangeWeapon(string name, int dmg)
        {
            Name = name;
            Slot = EquipmentSlot.RangeWeapon;
            BonusDamage = dmg;
            MaxDurability = 7;
            Durability = MaxDurability;
        }
    }
}
