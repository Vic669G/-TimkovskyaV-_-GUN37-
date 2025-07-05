using System;
using System.Collections.Generic;

namespace DungeonRPG
{
    enum EquipmentSlot { Weapon, Armour, RangeWeapon, Helmet }
    enum Difficulty { Easy, Medium, Hard }

    abstract class Unit
    {
        public string Name;
        public int MaxHealth;
        public int CurrentHealth;
        public int BaseDamage;
        public List<Item> Inventory = new();
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

        public abstract void Attack(Unit target);

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

    class Player : Unit
    {
        public override void Attack(Unit target)
        {
            int totalDamage = BaseDamage;
            if (EquipmentSlots.ContainsKey(EquipmentSlot.Weapon))
                totalDamage += ((Weapon)EquipmentSlots[EquipmentSlot.Weapon]).Damage;

            Console.WriteLine($"{Name} attacks {target.Name} for {totalDamage} damage!");
            target.TakeDamage(totalDamage);
        }

        public void EquipItem(Equipment item)
        {
            if (EquipmentSlots.ContainsKey(item.Slot))
            {
                Console.WriteLine($"Replace {EquipmentSlots[item.Slot].Name} with {item.Name}? (yes/no)");
                if (InputHelper.GetYesOrNo() == "yes")
                    EquipmentSlots[item.Slot] = item;
            }
            else
            {
                EquipmentSlots[item.Slot] = item;
                Console.WriteLine($"Equipped {item.Name}.");
            }
        }

        public void RepairEquipment()
        {
            foreach (var item in Inventory)
            {
                if (item is Whetstone stone && stone.Quantity > 0)
                {
                    stone.Use(this);
                    stone.Quantity--;
                    Console.WriteLine("Used Whetstone to repair equipment.");
                    return;
                }
            }
            Console.WriteLine("No Whetstone found!");
        }
    }

    class Goblin : Unit
    {
        public Goblin()
        {
            Name = "Goblin";
            MaxHealth = 15;
            CurrentHealth = 15;
            BaseDamage = 4;
        }

        public override void Attack(Unit target)
        {
            Console.WriteLine("Goblin attacks!");
            target.TakeDamage(BaseDamage);
        }
    }

    // --- Items ---
    abstract class Item
    {
        public string Name;
        public bool IsStackable = false;
    }

    abstract class Equipment : Item
    {
        public EquipmentSlot Slot;
        public int Durability;
        public int MaxDurability;

        public void TakeWear()
        {
            Durability--;
            if (Durability <= 0)
                Console.WriteLine($"{Name} broke!");
        }
    }

    class Weapon : Equipment
    {
        public int Damage;
        public Weapon(string name, int dmg)
        {
            Name = name;
            Slot = EquipmentSlot.Weapon;
            Damage = dmg;
            MaxDurability = 10;
            Durability = MaxDurability;
        }
    }

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

    class Gold : Item
    {
        public int Amount;
        public Gold(int amt)
        {
            Name = "Gold";
            Amount = amt;
            IsStackable = true;
        }
    }

    abstract class Consumable : Item
    {
        public int Quantity;
        public int Value;
        public abstract void Use(Player player);
    }

    class HealthPotion : Consumable
    {
        public HealthPotion()
        {
            Name = "Health Potion";
            Quantity = 1;
            Value = 7;
        }

        public override void Use(Player player)
        {
            player.CurrentHealth = Math.Min(player.MaxHealth, player.CurrentHealth + Value);
            Console.WriteLine($"Healed {Value} HP. Current HP: {player.CurrentHealth}");
        }
    }

    class Whetstone : Consumable
    {
        public Whetstone()
        {
            Name = "Whetstone";
            Quantity = 1;
            Value = 4;
        }

        public override void Use(Player player)
        {
            foreach (var eq in player.EquipmentSlots.Values)
            {
                eq.Durability = Math.Min(eq.MaxDurability, eq.Durability + Value);
            }
        }
    }

    // --- Battle ---
    class Battle
    {
        public static void Start(Player player, Unit enemy)
        {
            Console.WriteLine($"A wild {enemy.Name} appears!");
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                Console.WriteLine("\nChoose: 1-Rock  2-Paper  3-Scissors");
                int pChoice = InputHelper.GetChoice(1, 3);
                int eChoice = Random.Shared.Next(1, 4);

                Console.WriteLine($"Enemy chose {(eChoice == 1 ? "Rock" : eChoice == 2 ? "Paper" : "Scissors")}");

                if (pChoice == eChoice)
                {
                    Console.WriteLine("Draw!");
                }
                else if ((pChoice == 1 && eChoice == 3) || (pChoice == 2 && eChoice == 1) || (pChoice == 3 && eChoice == 2))
                {
                    player.Attack(enemy);
                }
                else
                {
                    int raw = enemy.BaseDamage;
                    int reduction = player.EquipmentSlots.ContainsKey(EquipmentSlot.Armour)
                        ? ((Armour)player.EquipmentSlots[EquipmentSlot.Armour]).ProtectionPercent : 0;

                    int damage = raw * (100 - reduction) / 100;
                    enemy.Attack(player);
                    Console.WriteLine($"Damage reduced to {damage}");
                    player.TakeDamage(damage);
                }
            }

            if (player.CurrentHealth <= 0)
                Console.WriteLine("You died!");
            else
                Console.WriteLine($"Defeated {enemy.Name}!");
        }
    }

    // --- Dungeon ---
    class DungeonRoom
    {
        public string Name;
        public Unit Enemy;
        public List<Item> Loot = new();
        public bool IsFinal;
        public Dictionary<int, DungeonRoom> Neighbors = new();
    }

    static class DungeonFactory
    {
        public static DungeonRoom CreateDungeon()
        {
            var room1 = new DungeonRoom { Name = "Entry Hall", Enemy = new Goblin(), Loot = new() { new Gold(10), new Weapon("Sword", 3) } };
            var room2 = new DungeonRoom { Name = "Dark Cave", Enemy = new Goblin(), Loot = new() { new HealthPotion(), new Helmet("Leather Helmet") } };
            var room3 = new DungeonRoom { Name = "Final Chamber", Enemy = new Goblin(), Loot = new() { new Gold(20), new RangeWeapon("Bow", 2) }, IsFinal = true };

            room1.Neighbors[0] = room2;
            room2.Neighbors[0] = room3;

            return room1;
        }
    }

    static class InputHelper
    {
        public static int GetChoice(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;

                Console.WriteLine($"Enter number between {min} and {max}.");
            }
        }

        public static string GetYesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "yes" || input == "no")
                    return input;
                Console.WriteLine("Type 'yes' or 'no'.");
            }
        }
    }

    // --- Main ---
    class Game
    {
        public void Start()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Player player = new Player
            {
                Name = name,
                MaxHealth = 30,
                CurrentHealth = 30,
                BaseDamage = 5
            };

            DungeonRoom currentRoom = DungeonFactory.CreateDungeon();
            GameLoop(player, currentRoom);
        }

        void GameLoop(Player player, DungeonRoom room)
        {
            while (true)
            {
                Console.WriteLine($"\nYou are in: {room.Name}");
                if (room.Enemy != null)
                    Battle.Start(player, room.Enemy);

                foreach (var item in room.Loot)
                {
                    Console.WriteLine($"You found: {item.Name}");
                    if (item is Equipment eq)
                        player.EquipItem(eq);
                    else
                        player.Inventory.Add(item);
                }

                if (room.IsFinal)
                {
                    Console.WriteLine("You cleared the dungeon!");
                    break;
                }

                Console.WriteLine("Choose direction:");
                foreach (var kv in room.Neighbors)
                    Console.WriteLine($"{kv.Key}: {kv.Value.Name}");

                int next = InputHelper.GetChoice(0, room.Neighbors.Count - 1);
                room = room.Neighbors[next];
            }
        }
    }

    class Program
    {
        static void Main()
        {
            new Game().Start();
        }
    }
}
