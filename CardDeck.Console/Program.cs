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
            Bootstrap.Start();
            var container = Bootstrap.container;

            var deck = new Deck<PokerCard>();

            deck.Sort(false);
            deck.Shuffle();
        }
    }
}
