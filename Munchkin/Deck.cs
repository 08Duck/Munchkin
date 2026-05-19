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

        public Deck()
        {
            cards = new List<T>();
        }

        // Adds card to deck
        public void Add(T card)
        {
            cards.Add(card);
        }

        // Draws a card from the top of the deck
        public T Draw()
        {
            T card = cards[0];
            cards.RemoveAt(0);
            return card;
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
