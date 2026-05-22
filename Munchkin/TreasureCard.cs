using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{

    // TreasureCard is a baseclass for all Treasure type cards
    abstract class TreasureCard : Card
    {
        public TreasureCard(string name, string desc) : base(name, desc) { }
    }
}
