using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Domain.Entities;

public class Deck : IDeck
{
    public Queue<Card> Cards { get; private set; } = new();

    public Deck()
    {
        InitializeDeck();
    }
    
    private void InitializeDeck()
    {
        Cards = new Queue<Card>();
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
        var cardList = new List<Card>(Cards);

        var random = new Random();
        var n = cardList.Count;
        while (n > 1)
        {
            n--;
            var k = random.Next(n + 1);
            (cardList[k], cardList[n]) = (cardList[n], cardList[k]);
        }

        Cards = new Queue<Card>(cardList);
    }

    public Card DealCard()
    {
        if (Cards.Count == 0)
        {
            throw new InvalidOperationException("No cards available.");
        }

        return Cards.Dequeue();
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