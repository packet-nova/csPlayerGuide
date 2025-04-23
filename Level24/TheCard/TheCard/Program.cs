Color[] cardColors = new[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
Rank[] cardRanks = new[] {Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight,
    Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Percent, Rank.Caret, Rank.Ampersand };

foreach (Rank rank in cardRanks)
{
    foreach (Color color in cardColors)
    {
        Card card = new Card(rank, color);
        Console.WriteLine($"The {card.Color} {card.Rank}.");
    }
}

public class Card
{
    public Rank Rank { get; }
    public Color Color { get; }

    public Card(Rank rank, Color color)
    {
        Rank = rank;
        Color = color;
    }

    public bool IsSymbol => Rank == Rank.Dollar || Rank == Rank.Percent || Rank == Rank.Caret || Rank == Rank.Ampersand;
    public bool IsNumber => !IsSymbol;
}
public enum Color { Red, Green, Blue, Yellow }
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }