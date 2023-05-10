using CardGame.Domain.Entities;
using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Application.CardComparisonGame;

public class GameManager: IGameManager
{
    private readonly IPlayer _humanPlayer;
    private readonly IPlayer _computerPlayer;
    private int _playerScore;
    private int _computerScore;
    private readonly IDeck _deck;


    public GameManager(IDeck deck)
    {
        _humanPlayer = new Player(PlayerType.Human);
        _computerPlayer = new Player(PlayerType.Computer);
        _deck = deck;
        _playerScore = 0;
        _computerScore = 0;
    }

    public void ShuffleDeck()
    {
        throw new NotImplementedException();
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