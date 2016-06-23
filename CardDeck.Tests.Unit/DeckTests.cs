using System.Linq;
using CardDeck.Domain.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CardDeck.Tests.Unit
{
    [TestFixture]
    public class PokerDeckTests
    {
        [Test]
        public void Deck_initializes_correctly()
        {
            //Setup
            var deck = new PokerDeck();

            //Execute
            var cards = deck.CardsToList();

            //Verify
            cards.Should().HaveCount(52);
            cards.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void Deck_can_sort_cards_ascending()
        {
            //Setup
            var deck = new PokerDeck();

            //Execute
            deck.Sort();
            
            //Verify
            deck.CardsToList().Should().BeInAscendingOrder(x => x.Suit);
            foreach (var grouping in deck.CardsToList().GroupBy(x=>x.Suit))
            {
                grouping.ToList().Should().BeInAscendingOrder(x=>x.Value);
            }
        }

        [Test]
        public void Deck_can_sort_cards_descending()
        {
            //Setup
            var deck = new PokerDeck();

            //Execute
            deck.Sort(false);

            //Verify
            deck.CardsToList().Should().BeInDescendingOrder(x => x.Suit);
            foreach (var grouping in deck.CardsToList().GroupBy(x => x.Suit))
            {
                grouping.ToList().Should().BeInDescendingOrder(x => x.Value);
            }
        }

        [Test]
        public void Deck_can_shuffle_cards()
        {
            //Setup
            var deck = new PokerDeck();

            //Execute
            deck.Shuffle();
            var shuffle1 = deck.CardsToList();

            deck.Shuffle();
            var shuffle2 = deck.CardsToList();

            deck.Shuffle();
            var shuffle3 = deck.CardsToList();


            //Verify
            shuffle1.Should().NotBeSameAs(shuffle2);
            shuffle1.Should().NotBeSameAs(shuffle3);
            shuffle2.Should().NotBeSameAs(shuffle3);
            deck.CardsToList().Should().OnlyHaveUniqueItems();
        }
    }
}
