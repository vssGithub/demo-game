using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public interface ICard
    {
        string SuitSymbol { get; }
        Rank Rank { get; }
    }
}
