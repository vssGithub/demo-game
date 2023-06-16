using System.Collections.Generic;

namespace Blackjack
{
    public interface IDeck
    {
        void Shuffle();
        ICard DrawCard();
        List<ICard> Cards { get; }
    }
}
