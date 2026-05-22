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
        // Max items in hand
        public const int MaxHandSize = 5;

        // Cards in players hand
        public List<Card> Hand { get; set; }



        // Equiped itemslots
        public List<Weapon> Weapons { get; set; }
        public Armor EquippedArmor { get; set; }
        public Helmet EquippedHelmet { get; set; }

        // Automatically sets the starting level
        public Player(string name)
            : base(name, 1)
        {
            Hand = new List<Card>();
            Weapons = new List<Weapon>();
        }

        // Add a card to hand
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);

            CheckHandLimit();
        }

        // Checks if the player has more cards in hand than the max allowed and discards excess cards
        private void CheckHandLimit()
        {
            while (Hand.Count > MaxHandSize)
            {
                Card removed = Hand[0];

                Hand.RemoveAt(0);

                Console.WriteLine($"Hand limit reached! Discarded: {removed.Name}");
            }
        }

        // Equip items from hand if avalible
        public void EquipItem(Item item)
        {
            if (!Hand.Contains(item))
            {
                return;
            }

            // If the Item is a weapon
            if (item is Weapon weapon)
            {
                if (Weapons.Count >= 2)
                {
                    Weapon removedWeapon = Weapons[0];
                    Weapons.RemoveAt(0);
                    Hand.Add(removedWeapon);
                    Console.WriteLine($"{removedWeapon.Name} was unequipped.");
                }
                Weapons.Add(weapon);
            }

            

            // Armor handling
            else if (item is Armor armor)
            {
                if (EquippedArmor != null)
                {
                    Hand.Add(EquippedArmor);

                    Console.WriteLine($"{EquippedArmor.Name} was unequipped.");
                }

                EquippedArmor = armor;
            }

            // Helmet handling
            else if (item is Helmet helmet)
            {
                if (EquippedHelmet != null)
                {
                    Hand.Add(EquippedHelmet);

                    Console.WriteLine($"{EquippedHelmet.Name} was unequipped.");
                }

                EquippedHelmet = helmet;
            }

            Hand.Remove(item);
        }

        // Calculates the total fighting level the player has
        public override int GetPower()
        {
            int totalPower = Level;

            foreach (Weapon weapon in Weapons)
            {
                totalPower += weapon.Bonus;
            }

            if (EquippedArmor != null)
            {
                totalPower += EquippedArmor.Bonus;
            }

            if (EquippedHelmet != null)
            {
                totalPower += EquippedHelmet.Bonus;
            }

            return totalPower;
        }

        // Displays stats for the player
        public override void DisplayStats()
        {
            Console.WriteLine("=== PLAYER ===");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Power: {GetPower()}");

            Console.WriteLine("\n=== EQUIPMENT ===");

            Console.WriteLine("Weapons:");

            if (Weapons.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Weapon weapon in Weapons)
                {
                    Console.WriteLine($"{weapon.Name} (+{weapon.Bonus})");
                }
            }

            Console.WriteLine($"Armor: {(EquippedArmor != null ? EquippedArmor.Name : "None")}");
            Console.WriteLine($"Helmet: {(EquippedHelmet != null ? EquippedHelmet.Name : "None")}");

            Console.WriteLine($"\nHand Size: {Hand.Count}/{MaxHandSize}\n");
        }
    }
}
