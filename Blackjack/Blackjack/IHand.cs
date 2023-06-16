using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public interface IHand
    {
        void AddCard(ICard card);
        int GetTotalValue();
        string ToString();
        List<ICard> Cards { get; }
    }
}
