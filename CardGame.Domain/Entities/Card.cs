using CardGame.Domain.Enums;

namespace CardGame.Domain.Entities;

public class Card
{
    public Suit Suit { get; set; }
    public int Value { get; set; }
}