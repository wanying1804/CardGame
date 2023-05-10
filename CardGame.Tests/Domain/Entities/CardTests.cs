using CardGame.Domain.Entities;
using CardGame.Domain.Enums;

namespace CardGame.Tests.Domain.Entities;

public class CardTests
{
    
    [Fact]
    public void ShouldThrowsArgumentOutOfRangeException_WhenCardValueIsAboveThirteenOrBelowOne()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Card(Suit.Clubs, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Card(Suit.Clubs, 14));
    } 
   
    [Fact]
    public void ShouldReturnExpectedResult_WhenCompareWithTwoCards()
    {
        var card1 = new Card (Suit.Spades, 10);
        var card2 = new Card (Suit.Hearts, 12);
        var card3 = new Card (Suit.Hearts, 10);
        
        Assert.True(card2.CompareTo(card1) > 0);
        Assert.True(card1.CompareTo(card3) > 0);
    }
}