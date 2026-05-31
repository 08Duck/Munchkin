using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    // Weapon is a type of Item
    // Inherits from Item class
    class Weapon : Item
    {
        // Weapon always has the description "Weapon"
        public Weapon(string name, int bonus)
            : base(name, "Weapon", bonus)
        {

        }
    }
}
