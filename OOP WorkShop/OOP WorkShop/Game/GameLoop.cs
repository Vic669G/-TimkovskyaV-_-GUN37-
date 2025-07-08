using OOP_WorkShop.Attack;
using OOP_WorkShop.Dungeon;
using OOP_WorkShop.Item.Equipment;
using OOP_WorkShop.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WorkShop.Game
{
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
                {
                    Battle.Start(player, room.Enemy);
                }
                        

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
}
