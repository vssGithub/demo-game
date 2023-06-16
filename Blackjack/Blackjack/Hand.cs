using System.Collections.Generic;

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

            // As ace can be either 1 or 11, adjust the total value if necessary
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
