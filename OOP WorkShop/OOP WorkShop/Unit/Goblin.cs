using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Unit
{
    class Goblin : Units
    {
        public Goblin()
        {
            Name = "Goblin";
            MaxHealth = 15;
            CurrentHealth = 15;
            BaseDamage = 4;
        }

        public override void Attack(Units target)
        {
            Console.WriteLine("Goblin attacks!");
            target.TakeDamage(BaseDamage);
        }
    }
}
