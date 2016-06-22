namespace CardDeck.Console
{
    public interface ICard<T>
    {
        int value { get; set; }
        T suit { get; set; }
    }
}