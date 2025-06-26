BlockCoordinate coord = new(4, 3);

BlockCoordinate newNorthCoord = coord + (BlockOffset)Direction.North;
BlockCoordinate newSouthCoord = coord + (BlockOffset)Direction.South;
BlockCoordinate newEastCoord = coord + (BlockOffset)Direction.East;
BlockCoordinate newWestCoord = coord + (BlockOffset)Direction.West;

Console.WriteLine(newNorthCoord);
Console.WriteLine(newSouthCoord);
Console.WriteLine(newEastCoord);
Console.WriteLine(newWestCoord);

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

public record BlockOffset(int RowOffset, int ColumnOffset)
{ 
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(+1, 0),
            Direction.East => new BlockOffset(0, +1),
            Direction.West => new BlockOffset(0, -1),
            _ => new BlockOffset(0, 0),
        };
    }
}
public enum Direction { North, South, East, West }