using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Munchkin
{
    class GameManager
    {
        private Player player;

        // Decks used during the game
        private Deck<DoorCard> doorDeck;
        private Deck<TreasureCard> treasureDeck;

        public GameManager()
        {
            player = new Player("Player 1");

            doorDeck = new Deck<DoorCard>();
            treasureDeck = new Deck<TreasureCard>();

            // Fill and shuffle the decks
            FixDeck();
        }

        // Creates cards and fills decks
        private void FixDeck()
        {
            // Monsters
            doorDeck.Add(new MonsterCard(new Monster("Undead Horse", 1, 1)));
            doorDeck.Add(new MonsterCard(new Monster("Plutonium Dragon", 11, 3)));
            doorDeck.Add(new MonsterCard(new Monster("Flying Frogs", 2, 1)));
            doorDeck.Add(new MonsterCard(new Monster("Skeleton Dragon", 6, 2)));

            // Curses
            doorDeck.Add(new Curse("Curse! Lose 1 Level", -1));
            doorDeck.Add(new Curse("You tripped and lost 2 levels", -2));

            // Race cards
            doorDeck.Add(new RaceCard("Elf Heritage", "Elf"));
            doorDeck.Add(new RaceCard("Dwarf Heritage", "Dwarf"));

            // Class cards
            doorDeck.Add(new ClassCard("Warrior Training", "Warrior"));
            doorDeck.Add(new ClassCard("Wizard Training", "Wizard"));

            //Treasure cards
            treasureDeck.Add(new Helmet("Iron Helmet", 1));
            treasureDeck.Add(new Helmet("Dragon Crown", 3));
            treasureDeck.Add(new Weapon("Big Sword", 2));
            treasureDeck.Add(new Weapon("Mythic Axe", 4));
            treasureDeck.Add(new Armor("Steel Armor", 1));
            treasureDeck.Add(new Armor("Diamond Armor", 2));
            treasureDeck.Add(new Weapon("Shiny Spear", 3));

            // Shuffle decks 
            doorDeck.Shuffle();
            treasureDeck.Shuffle();
        }

        public void StartGame() // Starts the game
        {
            // Timer used as the player's score
            Stopwatch stopwatch = new Stopwatch(); 
            stopwatch.Start(); 
            Console.WriteLine("=== MUNCHKIN GAME ===\n");

            DrawStartingCards();

            bool running = true;
            

            while (running)
            {
                Console.WriteLine("______________");
                Console.WriteLine("|  New turn  |");
                Console.WriteLine("______________");

                player.DisplayStats();


                Console.WriteLine("Choose an action:\n1: Open Door\n2: Equip item from hand\n3: View hand");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        OpenDoor();
                        break;
                    
                    case "2":
                        EquipItemFromHand();
                        break;

                    case "3":
                        ShowHand();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                // Wait for player before starting next turn
                Console.WriteLine("Press spacebar to continue...");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        break;
                    }
                }

                Console.Clear();

                // Win condition
                if (player.Level >= 10)  
                {
                    Console.WriteLine("You won the game");

                    // Stops the timer and print your time/score
                    stopwatch.Stop();

                    Console.WriteLine($"Time: {stopwatch.Elapsed:mm\\:ss\\.ff}");
                    running = false;
                }
            }
        }


        /*
         I want to make it more gamne like so you draw door cards too but thats a work in progress 
         */

        // Gives the player two starting treasure cards
        private void DrawStartingCards() 
        {
            Console.WriteLine("Drawing starting cards...");

            for (int i = 0; i < 2; i++)
            {
                TreasureCard card = treasureDeck.Draw();

                player.AddCardToHand(card);

                Console.WriteLine($"Drew: {card.Name}");
            }
        }

        // Draws a doorcard and plays it
        private void OpenDoor() 
        {
            DoorCard card = doorDeck.Draw();

            Console.WriteLine("Opening the door\n");

            card.Display();

            // Encountering a monster
            if (card is MonsterCard monsterCard)
            {
                Console.WriteLine("Either chose to fight or run away!");
                Console.WriteLine("1: Fight\n2: Run away (33% success rate)");
                string input = Console.ReadLine() ?? ""; 
                if (input == "1")
                {
                    bool victory = BattleSystem.Fight(player, monsterCard.Enemy);

                    // Rewards player if they win
                    if (victory)
                    {
                        GiveTreasure();
                    }
                }
                else if (input == "2")  // Makes the running away event
                {
                    Random rand = new Random();
                    if (rand.Next(6) > 3)
                    {
                        Console.WriteLine("You successfully ran away!");
                    }
                    else
                    {
                        Console.WriteLine("You failed to run away and lost 1 level!");
                        player.Level -= 1;

                        if (player.Level < 1)
                        {
                            player.Level = 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice, you lose 1 level!");
                    player.Level -= 1;
                    if (player.Level < 1)
                    {
                        player.Level = 1;
                    }
                }
            }

            // Curse card
            else if (card is Curse curse)
            {
                Console.WriteLine(curse.Name);

                player.Level += curse.EffectValue;

                if (player.Level < 1)
                {
                    player.Level = 1;
                }
            }

            // Race card
            else if (card is RaceCard race)
            {
                Console.WriteLine($"You became a {race.RaceType}!");
            }
            // Class card
            else if (card is ClassCard classCard)
            {
                Console.WriteLine($"You became a {classCard.ClassType}!");
            }

            doorDeck.Discard(card);
            Console.WriteLine();
        }

        private void GiveTreasure()
        {
            Console.WriteLine("You earned a treasure\n");

            TreasureCard card = treasureDeck.Draw();

            player.AddCardToHand(card);

            Console.WriteLine($"Treasure: {card.Name}");

            treasureDeck.Discard(card);
        }

        // Allows the player to equip an item from their hand
        private void EquipItemFromHand()
        {
            List<Item> itemsInHand = new List<Item>();

            foreach (Card card in player.Hand)
            {
                if (card is Item item)
                {
                    itemsInHand.Add(item);
                }
            }

            // Incase you dont have anything in your hand
            if (itemsInHand.Count == 0) 
            {
                Console.WriteLine("You have no items to equip.");

                return;
            }

            Console.WriteLine("\n=== ITEMS IN HAND ===");

            for (int i = 0; i < itemsInHand.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {itemsInHand[i].Name} (+{itemsInHand[i].Bonus})");
            }

            Console.WriteLine("Choose item number to equip:");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice >= 1 && choice <= itemsInHand.Count)
                {
                    Item selectedItem = itemsInHand[choice - 1];

                    player.EquipItem(selectedItem);

                    Console.WriteLine($"Equipped {selectedItem.Name}");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        // Shows all the players cards
        private void ShowHand()
        {
            Console.WriteLine("\n=== HAND ===");

            if (player.Hand.Count == 0)
            {
                Console.WriteLine("Hand is empty.");

                return;
            }

            for (int i = 0; i < player.Hand.Count; i++)
            {
                Card card = player.Hand[i];

                Console.WriteLine($"{i + 1}: {card.Name} ({card.Description})");
            }
        }
    }
}
