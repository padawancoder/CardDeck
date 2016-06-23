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
            var cards = deck.Cards();

            //Verify
            cards.Should().HaveCount(52);
            cards.Should().OnlyHaveUniqueItems();
            cards.GroupBy(x => x.Suit).Should().HaveCount(4);
        }

        [Test]
        public void Deck_can_sort_cards_ascending()
        {
            //Setup
            var deck = new PokerDeck();

            //Execute
            deck.Shuffle();
            var unshuffled = deck.Cards().ToList();
            deck.Sort();

            //Verify

            Assert.That(unshuffled, Is.Not.Ordered.By("Suit")); 
            Assert.That(unshuffled, Is.Not.Ordered.By("Value"));

            deck.Cards().Should().BeInAscendingOrder(x => x.Suit);
            foreach (var grouping in deck.Cards().GroupBy(x=>x.Suit))
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
            deck.Shuffle();
            var unshuffled = deck.Cards().ToList();
            deck.Sort(false);

            //Verify
            Assert.That(unshuffled, Is.Not.Ordered.By("Suit")); 
            Assert.That(unshuffled, Is.Not.Ordered.By("Value"));


            deck.Cards().Should().BeInDescendingOrder(x => x.Suit);
            foreach (var grouping in deck.Cards().GroupBy(x => x.Suit))
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
            deck.Sort();
            var sorted = deck.Cards().ToList();

            deck.Shuffle();
            var shuffle1 = deck.Cards();

            deck.Shuffle();
            var shuffle2 = deck.Cards();

            deck.Shuffle();
            var shuffle3 = deck.Cards();


            //Verify
            sorted.Should().BeInAscendingOrder(x => x.Suit); //test that everything is sorted

            shuffle1.Should().NotBeSameAs(shuffle2); //test that everything gets shuffled and is different each time.
            shuffle1.Should().NotBeSameAs(shuffle3);
            shuffle2.Should().NotBeSameAs(shuffle3);
            deck.Cards().Should().OnlyHaveUniqueItems();

            Assert.That(shuffle1, Is.Not.Ordered.By("Suit")); 
            Assert.That(shuffle1, Is.Not.Ordered.By("Value"));

        }
    }
}
