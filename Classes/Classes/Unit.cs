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
        private float _health;
        public string Name { get; }
        public float Health => _health;
        public int Damage { get; }
        public float Armor { get; }

        public Unit() : this(name: "Unknown Unit") { }
        public Unit(string name)
        {
            Name = name;
            _health = 100f;
            Damage = 5;
            Armor = 0.6f;
        }
        public float RealHealth()
        {
            return _health * (1f + Armor);
        }
        public bool SetDamage(float value)
        {
            _health -= value * Armor;
            if (_health <= 0f)
            {
                _health = 0f;
                return true;
            }
            return false;
        }

    }
}
