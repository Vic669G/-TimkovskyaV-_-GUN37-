using OOP_WorkShop.Item.Equipment;
using OOP_WorkShop.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OOP_WorkShop.Item.Consumable;

namespace OOP_WorkShop.Unit
{
    enum EquipmentSlot { Weapon, Armour, RangeWeapon, Helmet }
    enum Difficulty { Easy, Medium, Hard }

    abstract class Units
    {
        public string Name;
        public int MaxHealth;
        public int CurrentHealth;
        public int BaseDamage;
        public List<GameItem> Inventory = new();
        public Dictionary<EquipmentSlot, Equipment> EquipmentSlots = new();

        public virtual void TakeDamage(int damage)
        {
            if (EquipmentSlots.ContainsKey(EquipmentSlot.Armour))
                EquipmentSlots[EquipmentSlot.Armour].TakeWear();

            if (EquipmentSlots.ContainsKey(EquipmentSlot.Helmet))
                EquipmentSlots[EquipmentSlot.Helmet].TakeWear();

            CurrentHealth -= damage;
            if (CurrentHealth < 0) CurrentHealth = 0;
            Console.WriteLine($"{Name} took {damage} damage. Remaining HP: {CurrentHealth}");
        }

        public abstract void Attack(Units target);

        public void UseConsumablesAfterBattle()
        {
            foreach (var item in Inventory)
            {
                if (item is HealthPotion hp && hp.Quantity > 0)
                {
                    Console.WriteLine("Using Health Potion.");
                    hp.Use((Player)this);
                    break;
                }
            }
        }
    }
}
