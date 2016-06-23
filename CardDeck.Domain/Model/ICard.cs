using System;

namespace CardDeck.Domain.Model
{
    public interface ICard
    {
        Enum Suit { get; set; } 

        int Value { get; set; }
    }
}