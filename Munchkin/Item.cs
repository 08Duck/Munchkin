using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    // Base class for all items
    abstract class Item : TreasureCard
    {
        // Bonus value added to player power
        public int Bonus { get; set; }

        public Item(string name, string desc, int bonus)
            : base (name, desc)
        {
            Bonus = bonus;
        }

        // Displays item info
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Bonus + {Bonus}");
        }
    }
}
