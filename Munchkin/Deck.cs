using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    // Generic deck that can store any type of card
    class Deck<T>
    {
        // Internal list of cards 
        private List<T> cards;

        private List<T> discardPile;

        private Random random = new Random();

        public Deck()
        {
            cards = new List<T>();

            discardPile = new List<T>();
        }

        // Adds card to deck
        public void Add(T card)
        {
            cards.Add(card);
        }

        // Draws a card from the top of the deck
        public T Draw()
        {
            if (cards.Count == 0)
            {
                Reshuffle();
            }

            T card = cards[0];

            cards.RemoveAt(0);

            return card;
        }

        // Add to discard pile
        public void Discard(T card)
        {
            discardPile.Add(card);
        }

        // Reshuffle discard pile
        private void Reshuffle()
        {
            if (discardPile.Count == 0)
            {
                return;
            }

            Console.WriteLine("\nDeck empty! Reshuffling discard pile...\n");

            cards.AddRange(discardPile);

            discardPile.Clear();

            Shuffle();
        }


        // Shuffles deck
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(cards.Count);

                T temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        // Returns how many cards are in the deck
        public int Count()
        {
            return cards.Count;
        }
    }
}
