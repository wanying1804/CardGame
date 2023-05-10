using CardGame.Domain.Entities;

namespace CardGame.Tests.Domain.Entities;

public class DeckTests
{
    
    [Fact]
    public void ShouldGenerateFiftyTwoCards_WhenInitializingANewDeck()
    {
        // Arrange
        Deck deck = new Deck();
        int expectedCardCount = 52;

        // Act
        int actualCardCount = deck.Cards.Count;

        // Assert
        Assert.Equal(expectedCardCount, actualCardCount);
    } 
    
}