using CardGame.Application.CardComparisonGame;
using CardGame.Domain.Interfaces;
using Moq;

namespace CardGame.Tests.Application;

public class GameManagerTests
{
    private readonly Mock<IDeck> _deckMock;
    private readonly GameManager _gameManager;

    public GameManagerTests()
    {
        _deckMock = new Mock<IDeck>();;
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
    public void DealCards_ShouldReturnDictionaryWithTwoCards()
    {
        // Act
        var dealtCards = _gameManager.DealCards();

        // Assert
        Assert.Equal(2, dealtCards.Count);
        Assert.Contains(_gameManager.HumanPlayer, dealtCards.Keys);
        Assert.Contains(_gameManager.ComputerPlayer, dealtCards.Keys);
        Assert.All(dealtCards.Values, card => Assert.NotNull(card));
    }
}