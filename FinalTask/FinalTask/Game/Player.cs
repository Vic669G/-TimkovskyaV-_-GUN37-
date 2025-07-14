using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    public class Player
    {
        public string Name { get; set; }
        public int Bank { get; set; }

        public Player() { }

        public Player(string name, int bank = 1000)
        {
            Name = name;
            Bank = bank;
        }
    }
}
