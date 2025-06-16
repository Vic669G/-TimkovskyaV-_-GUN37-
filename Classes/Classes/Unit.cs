using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Unit
    {
        private float health;

        public string Name { get; }
        public float Health => health;
        public float Armor { get; } = 0.6f;
        public Interval DamageRange { get; }

        public Unit() : this("Unknown Unit") { }

        public Unit(string name) : this(name, 0, 5) { }

        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            health = 100f;
            DamageRange = new Interval(minDamage, maxDamage);
        }

        public float GetRealHealth()
        {
            return health * (1f + Armor);
        }

        public bool SetDamage(float value)
        {
            health -= value * Armor;
            if (health <= 0f)
            {
                health = 0f;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name} (Health: {Health}, Damage: {DamageRange})";
        }
    }
}

