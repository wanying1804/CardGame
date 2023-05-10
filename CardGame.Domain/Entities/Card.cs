using CardGame.Domain.Enums;

namespace CardGame.Domain.Entities;

public class Card: IComparable<Card>
{
    private int _value;
    public Suit Suit { get;}
    public int Value
    {
        get { return _value; }
        set
        {
            if (value >= 1 && value <= 13)
                _value = value;
            else
                throw new ArgumentOutOfRangeException("Value must be between 1 and 13.");
        }
    }

    public Card(Suit suit, int value)
    {
        Suit = suit;
        Value = value;
    }

    public int CompareTo(Card? other)
    {
        // Compare by value first
        int valueComparison = Value.CompareTo(other?.Value);

        if (valueComparison != 0)
        {
            return valueComparison;
        }

        // If value are the same, compare by suit
        return Suit.CompareTo(other?.Suit);
    }
}