using System.Collections.Generic;
using System.Linq;

namespace CardDeck.Domain.Model
{
    /// <summary>
    /// All card decks should implement these methods. 
    /// </summary>
    public interface IDeck
    {
        void Shuffle();
        void Sort(bool asc);
        IQueryable<ICard> Cards();
    }
}