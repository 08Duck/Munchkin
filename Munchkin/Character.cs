using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    // Base class for all characters (player and monsters)
    abstract class Character
    {
        public string Name;
        public int Level;

        // Sets name and level
        public Character(string name, int level)
        {
            Name = name;
            Level = level;
        }

        // Returns power based on level
        public virtual int GetPower()
        {
            return Level;
        }

        // Displays basic info about the character
        public virtual void DisplayStats()
        {
            Console.WriteLine($"{Name} | Level: {Level}");
        }
    }
}