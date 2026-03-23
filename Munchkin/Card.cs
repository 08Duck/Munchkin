using Munchkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    abstract class Card
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Alla kort kan visa sig själva (ASCII)
        public virtual void Display()
        {
            Console.WriteLine("+----------------------+");
            Console.WriteLine($"| {Name.PadRight(20)} |");
            Console.WriteLine("|----------------------|");
            Console.WriteLine($"| {Description.PadRight(20)} |");
            Console.WriteLine("+----------------------+");
        }
    }
}






