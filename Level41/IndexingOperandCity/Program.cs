BlockCoordinate coord = new(4, 3);
BlockOffset offset = new(2, 0);

BlockCoordinate newCoord = coord + offset;
Console.WriteLine($"{newCoord.Row}, {newCoord.Column}");

BlockCoordinate coordPlusNorth = coord + Direction.North;
BlockCoordinate coordPlusSouth = coord + Direction.South;
BlockCoordinate coordPlusEast = coord + Direction.East;
BlockCoordinate coordPlusWest = coord + Direction.West;

Console.WriteLine($"Original coord: ({coord.Row}, {coord.Column}) - Moving North coord: ({coordPlusNorth.Row}, {coordPlusNorth.Column})");
Console.WriteLine($"Original coord: ({coord.Row}, {coord.Column}) - Moving South coord: ({coordPlusSouth.Row}, {coordPlusSouth.Column})");
Console.WriteLine($"Original coord: ({coord.Row}, {coord.Column}) - Moving East coord: ({coordPlusEast.Row}, {coordPlusEast.Column})");
Console.WriteLine($"Original coord: ({coord.Row}, {coord.Column}) - Moving West coord: ({coordPlusWest.Row}, {coordPlusWest.Column})");

Console.WriteLine($"Original row coordinate: {coord[0]}");
Console.WriteLine($"Original column coordinate: {coord[1]}");

public record BlockCoordinate(int Row, int Column)
{
    public int this[int index]
    {
        get
        {
            if (index == 0) return Row;
            else return Column;
        }
    }
    public static BlockCoordinate operator +(BlockCoordinate coord, BlockOffset offset) =>
        new BlockCoordinate(coord.Row + offset.RowOffset, coord.Column + offset.ColumnOffset);

    public static BlockCoordinate operator +(BlockCoordinate coord, Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockCoordinate(coord.Row - 1, coord.Column),
            Direction.East => new BlockCoordinate(coord.Row, coord.Column + 1),
            Direction.South => new BlockCoordinate(coord.Row + 1, coord.Column),
            Direction.West => new BlockCoordinate(coord.Row, coord.Column - 1),
            _ => new BlockCoordinate(coord.Row, coord.Column)
        };
    }
}

public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, South, East, West }