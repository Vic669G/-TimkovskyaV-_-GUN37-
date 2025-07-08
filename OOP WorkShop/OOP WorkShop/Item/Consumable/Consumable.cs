using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item.Consumable
{
    abstract class Consumable : GameItem
    {
        public int Quantity;
        public int Value;
        public abstract void Use(Player player);
    }
}
