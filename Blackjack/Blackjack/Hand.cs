using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class Hand : IHand
    {
        public List<ICard> Cards { get; private set; }

        public Hand()
        {
            Cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            Cards.Add(card);
        }

        public int GetTotalValue()
        {
            int totalValue = 0;
            int numAces = 0;

            foreach (ICard card in Cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    totalValue += 11;
                    numAces++;
                }
                else if (card.Rank >= Rank.Ten)
                {
                    totalValue += 10;
                }
                else
                {
                    totalValue += (int)card.Rank;
                }
            }

            // Adjust the value of Aces if necessary
            while (totalValue > 21 && numAces > 0)
            {
                totalValue -= 10;
                numAces--;
            }

            return totalValue;
        }

        public override string ToString()
        {
            return string.Join(", ", Cards);
        }
    }
}
