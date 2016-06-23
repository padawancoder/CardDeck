using System;

namespace CardDeck.Domain.Model
{
    public class PokerCard : ICard
    {
        public PokerCard(Suit suit, int value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public Enum Suit { get; set; }
        public int Value { get; set; }
    }
}