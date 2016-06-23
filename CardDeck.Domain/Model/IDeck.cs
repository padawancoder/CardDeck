using System.Collections.Generic;

namespace CardDeck.Domain.Model
{
    /// <summary>
    /// Each implementation of IDeck will build it's on deck. Maybe you'd rather play Uno then Poker?
    /// </summary>
    public interface IDeck
    {
        void Shuffle();
        void Sort(bool asc);
        List<ICard> CardsToList();
    }
}