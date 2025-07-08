using OOP_WorkShop.Item;
using OOP_WorkShop.Unit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Dungeon
{
    class DungeonRoom
    {
        public string Name;
        public Units Enemy;
        public List<GameItem> Loot = new();
        public bool IsFinal;
        public Dictionary<int, DungeonRoom> Neighbors = new();
    }
}
