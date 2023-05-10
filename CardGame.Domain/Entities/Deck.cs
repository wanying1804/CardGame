using CardGame.Domain.Interfaces;

namespace CardGame.Domain.Entities;

public class Deck: IDeck
{
    public Queue<Card> _cards;

    public Deck()
    {
        _cards = new Queue<Card>();
    }

    public void Shuffle()
    {
        throw new NotImplementedException();
    }

    public Card DealCard()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public int LeftCardsCount()
    {
        throw new NotImplementedException();
    }
}