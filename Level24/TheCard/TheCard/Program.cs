CardColor[] cardColors = new[] { CardColor.Red, CardColor.Green, CardColor.Blue, CardColor.Yellow };
CardRank[] cardRanks = new[] {CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight,
    CardRank.Nine, CardRank.Ten, CardRank.Dollar, CardRank.Percent, CardRank.Caret, CardRank.Ampersand };

foreach (CardRank rank in cardRanks)
{
    foreach (CardColor color in cardColors)
    {
        Card card = new Card(rank, color);
        Console.WriteLine($"The {card.Color} {card.Rank}.");
    }
}

public class Card
{
    public CardRank Rank { get; }
    public CardColor Color { get; }

    public Card(CardRank rank, CardColor color)
    {
        Rank = rank;
        Color = color;
    }

    public bool IsSymbol => Rank == CardRank.Dollar || Rank == CardRank.Percent || Rank == CardRank.Caret || Rank == CardRank.Ampersand;
    public bool IsNumber => !IsSymbol;
}
public enum CardColor { Red, Green, Blue, Yellow }
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }