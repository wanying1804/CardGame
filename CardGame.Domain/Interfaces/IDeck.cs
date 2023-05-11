using CardGame.Domain.Entities;

namespace CardGame.Domain.Interfaces;

public interface IDeck
{
    public Queue<Card> Cards { get; }
    void Shuffle();
    Card DealCard();
    void Reset();
    void ResetAndShuffle();
}