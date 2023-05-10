using CardGame.Application.CardComparisonGame;
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
        var sequence = new MockSequence();
        
        _deckMock.SetupSequence(d => d.DealCard())
            .Returns(new Card(Suit.Hearts, 2))
            .Returns(new Card(Suit.Diamonds, 5));
        
        _gameManager = new GameManager(_deckMock.Object);
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
        // Act

        var dealtCards = _gameManager.DealCards();

        // Assert
        Assert.Equal(2, dealtCards.Count);
        Assert.Equal(Suit.Hearts, dealtCards[_gameManager.HumanPlayer].Suit);
        Assert.Equal(2, dealtCards[_gameManager.HumanPlayer].Value);
        Assert.Equal(Suit.Diamonds, dealtCards[_gameManager.ComputerPlayer].Suit);
        Assert.Equal(5, dealtCards[_gameManager.ComputerPlayer].Value);
    }
}