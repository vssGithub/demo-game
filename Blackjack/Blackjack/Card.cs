using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class Card : ICard
    {
        public string SuitSymbol { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            SuitSymbol = GetSuitSymbol(suit);
            Rank = rank;
        }

        private string GetSuitSymbol(Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts:
                    return "♥";
                case Suit.Diamonds:
                    return "♦";
                case Suit.Clubs:
                    return "♣";
                case Suit.Spades:
                    return "♠";
                default:
                    return "";
            }
        }

        public override string ToString()
        {
            return Rank.ToString() + SuitSymbol;
        }
    }
}
