class Card
{
    public CardRank Rank { get; }
    public CardColor Color { get; } 

    public Card(CardRank rank, CardColor color)
    {
        Rank = rank;
        Color = color;
    }

    public enum CardColor { Red, Green, Blue, Yellow }
    public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Chevron, Ampersand }
}