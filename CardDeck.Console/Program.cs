using System.Text;
using CardDeck.Domain.Model;

namespace CardDeck.Console
{
    /// <summary>
    /// This console application builds a standard 52 card poker deck. It sorts (asc and desc) and shuffles the deck.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new PokerDeck();

            deck.Shuffle();
            OutPutDeckToConsole(deck, "Deck is shuffled");

            deck.Sort();
            OutPutDeckToConsole(deck, "Deck is sorted in ascending");

            deck.Shuffle();
            OutPutDeckToConsole(deck, "Deck is shuffled");

            deck.Sort(false);
            OutPutDeckToConsole(deck, "Deck is sorted in descending");

        }

        /// <summary>
        /// Spits out order of cards in a deck to the console
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="headerMessage"></param>
        static void OutPutDeckToConsole(IDeck deck, string headerMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(headerMessage);

            foreach (var card in deck.Cards())
            {
                var cardValue = string.Format("{0}_{1}", card.Suit.ToString(), card.Value);
                stringBuilder.Append(cardValue + " ");
            }

            stringBuilder.AppendLine("\n");

            System.Console.WriteLine(stringBuilder.ToString());
        }
    }
}
