using CardGame.Domain.Entities;

namespace CardGame.Domain.Interfaces;

public interface IDeck
{
    void Shuffle();
    Card DealCard();
    void Reset();
    void ResetAndShuffle();
}