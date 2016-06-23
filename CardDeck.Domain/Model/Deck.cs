using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck.Domain.Model
{
    public class Deck
    {
        protected readonly List<ICard> cards = new List<ICard>();
        
        //seen this before, thought I'd use the "fiser-yates" shuffle algorithim
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

        //could use LINQ if returning new list, but since we're mutating the cards array let's use a Sort
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

        public List<ICard> CardsToList()
        {
            return cards.ToList();
        }
    }
}