using CardDeck.Console;

namespace CardDeck.Domain.Model
{
    public interface IDeck
    {
        void Shuffle();
        void Sort(bool asc);
    }
}