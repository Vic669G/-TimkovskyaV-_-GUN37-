using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Weapon
    {
        public string Name { get; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public float Durability { get; } = 1f;

        public Weapon(string name)
        {
            Name = name;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                int temp = minDamage;
                minDamage = maxDamage;
                maxDamage = temp;
                Console.WriteLine($"[Warning] Некорректные входные данные в SetDamageParams для оружия '{Name}': minDamage > maxDamage. Значения были поменяны местами.");
            }

            if (minDamage < 1)
            {
                minDamage = 1;
                Console.WriteLine($"[Warning] Минимальный урон для оружия '{Name}' не может быть меньше 1. Принудительно установлено значение 1.");
            }

            if (maxDamage <= 1)
            {
                maxDamage = 10;
                Console.WriteLine($"[Warning] Максимальный урон для оружия '{Name}' не может быть меньше или равен 1. Принудительно установлено значение 10.");
            }

            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }
    }
}
