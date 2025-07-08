using OOP_WorkShop.Unit;
using OOP_WorkShop.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_WorkShop.Item.Consumable;
using OOP_WorkShop.Item.Equipment;

namespace OOP_WorkShop.Dungeon
{
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
}
