using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck.Domain.Model
{
    /// <summary>
    /// Abstract implementation of a deck. Shuffling, sorting, and viewing the cards will be the same. Doesn't matter if you're looking at a Poker or an Uno deck.
    /// </summary>
    public abstract class Deck
    {
        protected readonly List<ICard> cards = new List<ICard>();

        /// <summary>
        /// Using the "fiser-yates" shuffle algorithm (sounds like a dance move) to shuffle the deck
        /// </summary>
        public void Shuffle()
        {
            int cardCount = cards.Count();
            var random = new Random();

            for (int i = 0; i < cardCount; i++)
            {
                int index = i + (int) (random.NextDouble()*(cardCount - i));
                var cardToMove = cards[index];
                cards[index] = cards[i];
                cards[i] = cardToMove;
            }
        }

        /// <summary>
        /// Sorts cards ascending by default
        /// </summary>
        /// <param name="asc"></param>
        public void Sort(bool asc = true)
        {
            cards.Sort(delegate(ICard x, ICard y)
            {
                if (!asc)
                {
                    var tmp = x;
                    x = y;
                    y = tmp;
                }

                var result = x.Suit.CompareTo(y.Suit);
                if (result == 0) result = x.Value.CompareTo(y.Value);
                return result;
            });
        }

        /// <summary>
        /// returns an IQueryable which can be used to query cards by criteria
        /// </summary>
        /// <returns></returns>
        public IQueryable<ICard> Cards()
        {
            return cards.AsQueryable();
        }
    }
}