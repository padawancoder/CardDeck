using System;

namespace CardDeck.Domain.Model
{
    public class PokerCard : ICard
    {
        /// <summary>
        /// Implementation of a Poker card.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="value"></param>
        public PokerCard(Suit suit, int value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public Enum Suit { get; set; }
        public int Value { get; set; }
    }
}