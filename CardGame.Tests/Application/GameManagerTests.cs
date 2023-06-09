﻿using CardGame.Application.CardGameService;
using CardGame.Domain.Entities;
using CardGame.Domain.Enums;
using CardGame.Domain.Interfaces;
using Moq;

namespace CardGame.Tests.Application;

public class GameManagerTests
{
    private readonly Mock<IDeck> _deckMock;
    private readonly GameManager _gameManager;

    public GameManagerTests()
    {
        _deckMock = new Mock<IDeck>();
        _gameManager = new GameManager(_deckMock.Object);
    }

    private void Setup()
    {
        _deckMock.SetupSequence(d => d.DealCard())
            .Returns(new Card(Suit.Hearts, 2))
            .Returns(new Card(Suit.Diamonds, 5));
    }
    
    private void SetupForMultipleRounds()
    {
        _deckMock.SetupSequence(d => d.DealCard())
            .Returns(new Card(Suit.Hearts, 2))
            .Returns(new Card(Suit.Diamonds, 5))
            .Returns(new Card(Suit.Spades, 10))
            .Returns(new Card(Suit.Diamonds, 3))
            .Returns(new Card(Suit.Clubs, 6))
            .Returns(new Card(Suit.Hearts, 5));
    }

    
    [Fact]
    public void ShouldCallShuffleMethod_WhenShuffleTheDeck()
    {
        // Act
        _gameManager.ShuffleDeck();

        // Assert
        _deckMock.Verify(d => d.Shuffle(), Times.Once);
    }
    
    [Fact]
    public void ShouldReturnDictionaryWithTwoCards_WhenDealCards()
    {
        Setup();
        // Act
        var dealtCards = _gameManager.DealCards();

        // Assert
        Assert.Equal(2, dealtCards.Count);
        Assert.Equal(Suit.Hearts, dealtCards[_gameManager.HumanPlayer].Suit);
        Assert.Equal(2, dealtCards[_gameManager.HumanPlayer].Value);
        Assert.Equal(Suit.Diamonds, dealtCards[_gameManager.ComputerPlayer].Suit);
        Assert.Equal(5, dealtCards[_gameManager.ComputerPlayer].Value);
    }
    
    [Fact]
    public void ShouldReturnsRoundWinner_WhenRunGetWinnerForCurrentRoundMethod()
    {
        Setup();
        // Act
        _gameManager.DealCards();
        var roundWinner = _gameManager.GetWinnerForCurrentRound();

        // Assert
        Assert.Equal(_gameManager.ComputerPlayer, roundWinner);
    }
    
    [Fact]
    public void ShouldReturnsCurrentScoresForEachPlayer_WhenGetCurrentScores()
    {
        Setup();
        _gameManager.DealCards();
        _gameManager.GetWinnerForCurrentRound();
        // Act
        var scores = _gameManager.GetCurrentScores();

        // Assert
        Assert.Equal(0, scores.PlayerScore);
        Assert.Equal(1, scores.ComputerScore);
    }
    
    [Fact]
    public void ResetGame_ResetsDeckAndScores()
    {
        Setup();
        _gameManager.DealCards();
        _gameManager.GetWinnerForCurrentRound();
        var scoresBefore = _gameManager.GetCurrentScores();
        Assert.Equal(1, scoresBefore.ComputerScore);
        
        // Act
        _gameManager.ResetGame();

        // Assert
        _deckMock.Verify(d => d.Reset(), Times.Once);
        var scores = _gameManager.GetCurrentScores();
        Assert.Equal(0, scores.PlayerScore);
        Assert.Equal(0, scores.ComputerScore);
    }
    
    [Fact]
    public void ShouldReturnTheCorrectWinner_WhenGetWinnerForAllRound()
    {
        SetupForMultipleRounds();
        _gameManager.DealCards();
        _gameManager.GetWinnerForCurrentRound();
        _gameManager.DealCards();
        _gameManager.GetWinnerForCurrentRound();
        _gameManager.DealCards();
        _gameManager.GetWinnerForCurrentRound();

        // Act
        var winner = _gameManager.GetWinnerForAllRounds();
        var scores = _gameManager.GetCurrentScores();
        // Assert
        
        Assert.Equal(2, scores.PlayerScore);
        Assert.Equal(1, scores.ComputerScore);
        Assert.Equal(_gameManager.HumanPlayer, winner);
    }

}