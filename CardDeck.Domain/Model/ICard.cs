using System;

namespace CardDeck.Domain.Model
{
    /// <summary>
    /// General interface for a card
    /// </summary>
    public interface ICard
    {
        Enum Suit { get; set; } 

        int Value { get; set; }
    }
}