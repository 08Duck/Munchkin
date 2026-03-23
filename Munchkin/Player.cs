using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public List<Card> Hand { get; set; }
        public List<Item> Equipment { get; set; }

        public Player(string name)
        {
            Name = name
            Level = 1;

            Hand = new List<Card>();
            Equipment = new List<Item>();
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void EquipItem(Item item)
        {
            if (Hand.Contains(item))
            {
                Equipment.Add(item);
                Hand.Remove(item);
            }
        }


    }
}
