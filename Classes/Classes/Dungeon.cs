using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    using System;

    public class Dungeon
    {
        private Room[] rooms;

        public Dungeon()
        {
            rooms = new Room[]
            {
            new Room(new Unit("Knight", 2, 8), new Weapon("Sword", 5, 15)),
            new Room(new Unit("Archer", 1, 6), new Weapon("Bow", 3, 12)),
            new Room(new Unit("Mage", 3, 10), new Weapon("Staff", 6, 14))
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine($"Room #{i + 1}");
                Console.WriteLine("Unit of room: " + room.Unit);
                Console.WriteLine("Weapon of room: " + room.Weapon);
                Console.WriteLine("—");
            }
        }
    }

}
