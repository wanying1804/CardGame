using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Domain.Entities;

public class GameManager: IGameManager
{
    private readonly Player _humanPlayer;
    private readonly Player _computerPlayer;
    private int _playerScore;
    private int _computerScore;
    private readonly Deck _deck;


    public GameManager()
    {
        _humanPlayer = new Player(PlayerType.Human);
        _computerPlayer = new Player(PlayerType.Computer);
        _deck = new Deck();
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