using CardDeck.Console;

namespace CardDeck.Domain.Model
{
    public class PokerCard : ICard<Suit>
    {
        public PokerCard(Suit suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public Suit suit { get; set; } 

        public int value { get; set; }
    }
}