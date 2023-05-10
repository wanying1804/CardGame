using CardGame.Domain.Entities;
using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Application.CardComparisonGame;

public class GameManager: IGameManager
{
    public IPlayer HumanPlayer { get; init; }
    public IPlayer ComputerPlayer { get; init; }
    private int _playerScore;
    private int _computerScore;
    private readonly IDeck _deck;


    public GameManager(IDeck deck)
    {
        HumanPlayer = new Player(PlayerType.Human);
        ComputerPlayer = new Player(PlayerType.Computer);
        _deck = deck;
        _playerScore = 0;
        _computerScore = 0;
    }

    public void ShuffleDeck()
    {
        _deck.Shuffle();
    }

    public void ResetGame()
    {
        throw new NotImplementedException();
    }

    public Scores GetCurrentScores()
    {
        throw new NotImplementedException();
    }

    public IDictionary<Player, Card> DealCards()
    {
        throw new NotImplementedException();
    }

    public Player GetWinner()
    {
        throw new NotImplementedException();
    }
}