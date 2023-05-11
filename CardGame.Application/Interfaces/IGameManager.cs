using CardGame.Domain.Entities;

namespace CardGame.Application.Interfaces;

public interface IGameManager
{
    Player HumanPlayer { get; }
    Player ComputerPlayer { get; }
    void ShuffleDeck();
    void ResetGame();
    Scores GetCurrentScores();
    IDictionary<Player, Card> DealCards();
    Player? GetWinnerForAllRounds();
    Player? GetWinnerForCurrentRound();
}