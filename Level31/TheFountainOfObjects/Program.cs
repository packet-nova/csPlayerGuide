Location location = new(1, 2);
Player player = new();

Console.WriteLine(location);
Console.WriteLine(player.Location);



public record Location (int row, int column);

public enum Directions { North, South, East, West }
public enum RoomType { Entrance, Empty, Fountain, MapBoundary }