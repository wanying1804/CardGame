using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Domain.Entities;

public class Deck : IDeck
{
    public Queue<Card> Cards { get; } = new();

    public Deck()
    {
        InitializeDeck();
    }
    
    private void InitializeDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            for (int value = 1; value <= 13; value++)
            {
                Card card = new Card(suit, value);
                Cards.Enqueue(card);
            }
        }
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