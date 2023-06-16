using System;
using System.Collections.Generic;
using RandomizerLibrary;

namespace Blackjack
{
    public class Deck : IDeck
    {
        public List<ICard> Cards { get; private set; }
        private Randomizer randomizer;

        public Deck()
        {
            Cards = new List<ICard>();
            randomizer = new Randomizer();
            InitialiseDeck();
        }

        private void InitialiseDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            // Fisher-Yates shuffle algorithm
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = randomizer.GetSecureRng(n + 1);
                ICard temp = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = temp;
            }
        }

        public ICard DrawCard()
        {
            if (Cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty. Cannot draw card.");
            }

            ICard card = Cards[Cards.Count - 1];
            Cards.RemoveAt(Cards.Count - 1);

            return card;
        }
    }
}
