using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    // Armor is a type of Item
    class Armor : Item
    {
        // Armor always has the description "Armor"
        public Armor(string name, int bonus)
            : base (name, "Armor", bonus)
        {

        }
    }
}
