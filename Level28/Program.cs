Coordinate a = new(2, 2);
Coordinate b = new(4, 4);
Coordinate c = new(5, 5);
Coordinate d = new(3, 4);

Console.WriteLine($"Coordinates are adjacent: {Coordinate.IsAdjacent(a, b)}"); // Returns False
Console.WriteLine($"Coordinates are adjacent: {Coordinate.IsAdjacent(c, d)}"); // Returns True

public readonly struct Coordinate
{
    public readonly int Row;
    public readonly int Column;

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }
    public static bool IsAdjacent(Coordinate coord1, Coordinate coord2)
    {
        return (Math.Abs(coord1.Row - coord2.Row) == 1 || (Math.Abs(coord1.Column - coord2.Column) == 1));
    }
}