using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    abstract class DoorCard : Card
    {
        public DoorCard(string name, string desc) : base(name, desc) { }
    }
}
