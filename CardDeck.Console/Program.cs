using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDeck.Domain.Model;

namespace CardDeck.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new PokerDeck();
            deck.Shuffle();
            deck.Sort(false);
        }

        static void OutPutDeckToConsole(IDeck deck)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var card in deck.CardsToList())
            {
                var cardValue = string.Format("{0}_{1}", card.Suit.ToString(), card.Value);
                stringBuilder.Append(cardValue + " ");
            }

            System.Console.WriteLine(stringBuilder.ToString());
        }
    }
}
