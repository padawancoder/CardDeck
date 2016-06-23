using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck.Domain.Model
{
    public class PokerDeck : Deck, IDeck
    {
        public PokerDeck()
        {
            foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                for (int i = 0; i < 13; i++)
                {
                    var card = new PokerCard(suit, i);
                    cards.Add(card);
                }
            }
        }
    }
}