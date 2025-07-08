using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Item
{
    class Gold : GameItem
    {
        public int Amount;
        public Gold(int amt)
        {
            Name = "Gold";
            Amount = amt;
            IsStackable = true;
        }
    }
}
