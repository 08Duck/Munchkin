using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    class Player : Character
    {
        // Cards in players hand
        public List<Card> Hand { get; set; }

        // Equiped items
        public List<Item> Equipment { get; set; }
        
        // Automatically sets the starting level
        public Player(string name)
            : base(name, 1)
        {
            Hand = new List<Card>();
            Equipment = new List<Item>();
        }

        // Add a card to hand
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        // Equip items from hand if avalible
        public void EquipItem(Item item)
        {
            if (Hand.Contains(item))
            {
                Equipment.Add(item);
                Hand.Remove(item);
            }
        }

        // Calculates the total fighting level the player has
        public override int GetPower()
        {
            int totalbonus = Level;

            foreach (Item item in Equipment)
            {
                totalbonus += item.Bonus;
            }

            return totalbonus;
        }
        
        // Displays stats for the player
        public override void DisplayStats()
        {
            Console.WriteLine("=== PLAYER ===");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Power: {GetPower()}\n");
        }
    }
}
