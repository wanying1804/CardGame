﻿using CardGame.Application.Interfaces;
using CardGame.Domain.Entities;
using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;

namespace CardGame.Application.CardGameService;

public class GameManager: IGameManager
{
    public Player HumanPlayer { get; }
    public Player ComputerPlayer { get; }
    private int _playerScore;
    private int _computerScore;
    private readonly IDeck _deck;
    private IDictionary<Player, Card> _currentDealtCards;


    public GameManager(IDeck deck)
    {
        HumanPlayer = new Player(PlayerType.Human);
        ComputerPlayer = new Player(PlayerType.Computer);
        _currentDealtCards = new Dictionary<Player, Card>();
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
        _deck.Reset();
        _playerScore = 0;
        _computerScore = 0;
    }

    public Scores GetCurrentScores()
    {
        return new Scores(_playerScore, _computerScore);
    }

    public IDictionary<Player, Card> DealCards()
    {
        if (_deck.Cards.Count <= 1)
        {
            throw new InvalidOperationException("No enough cards");
        }
        
        IDictionary<Player, Card> dealtCards = new Dictionary<Player, Card>();
        dealtCards[HumanPlayer] = _deck.DealCard();
        dealtCards[ComputerPlayer] = _deck.DealCard();
        _currentDealtCards = dealtCards;
        return dealtCards;
    }

    public Player? GetWinnerForAllRounds()
    {
        if (_playerScore > _computerScore)
            return HumanPlayer;
        if (_computerScore > _playerScore)
            return ComputerPlayer;
        return null; // Tie
    }

    public Player? GetWinnerForCurrentRound()
    {
        if (!_currentDealtCards.ContainsKey(HumanPlayer) || !_currentDealtCards.ContainsKey(ComputerPlayer))
        {
            throw new InvalidOperationException("No dealt cards, please deal cards first");
        }

        Card humanCard = _currentDealtCards[HumanPlayer];
        Card computerCard = _currentDealtCards[ComputerPlayer];

        int roundResult = humanCard.CompareTo(computerCard);
        _currentDealtCards = new Dictionary<Player, Card>();

        if (roundResult > 0)
        {
            _playerScore++;
            return HumanPlayer;
        }
        else if (roundResult < 0)
        {
            _computerScore++;
            return ComputerPlayer;
        }
        else
        {
            return null;
        }
    }
}