using CardGame.Domain.Enums;

namespace CardGame.Tests.Domain.Enums;

public class SuitTests
{
    [Fact]
    public void ShouldReturnExpectedResult_WhenCompareToTwoSuits()
    {
        var spades = Suit.Spades;
        var hearts = Suit.Hearts;
        var diamonds = Suit.Diamonds;
        var clubs = Suit.Clubs;
        
        Assert.True(spades > hearts);
        Assert.True(hearts > diamonds);
        Assert.True(diamonds > clubs);
        Assert.True(spades == spades);
    }
}