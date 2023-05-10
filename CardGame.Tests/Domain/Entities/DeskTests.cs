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
    
    [Fact]
    public void ShouldRandomizeTheCards_WhenShuffleTheDeck()
    {
        // Arrange
        Deck deck = new Deck();
        Queue<Card> originalCards = new Queue<Card>(deck.Cards);

        // Act
        deck.Shuffle();
        Queue<Card> shuffledCards = deck.Cards;

        // Assert
        Assert.NotEqual(originalCards, shuffledCards);
    }
    
    [Fact]
    public void ShouldThrowException_WhenDealCardButNoCardAvailable()
    {
        // Arrange
        Deck deck = new Deck();
        var cardsTotal = deck.Cards.Count();
        for (int i = 0; i < cardsTotal; i++)
        {
            deck.DealCard();
        }

        // Assert
        Assert.Empty( deck.Cards);
        Assert.Throws<InvalidOperationException>(() => deck.DealCard());
    }
    
    [Fact]
    public void ShouldReturnTheFirstCard_WhenDealCard()
    {
        // Arrange
        Deck deck = new Deck();
        var firstCard = deck.Cards.First();

        // Act
        Card dealtCard = deck.DealCard();

        // Assert
        Assert.NotNull(dealtCard);
        Assert.Equal(firstCard, dealtCard);
    }
    
    [Fact]
    public void ShouldRestoresFiftyTwoCards_WhenResetTheDeck()
    {
        // Arrange
        Deck deck = new Deck();
        
        deck.DealCard();
        Assert.Equal(51, deck.Cards.Count);

        // Act
        deck.Reset();

        // Assert
        Assert.Equal(52, deck.Cards.Count);
    }
    
    [Fact] 
    public void ShouldRestoresAndShuffleTheCards_WhenResetAndShuffleTheDeck()
    {
        // Arrange
        Deck deck = new Deck();
        
        Queue<Card> originalCards = new Queue<Card>(deck.Cards);
        
        deck.DealCard();
        Assert.Equal(51, deck.Cards.Count);

        // Act
        deck.ResetAndShuffle();

        // Assert
        Assert.Equal(52, deck.Cards.Count);
        Assert.NotEqual(originalCards, deck.Cards);
    }


}