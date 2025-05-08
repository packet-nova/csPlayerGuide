//Location location = new(1, 2);
Player player = new();

Map map = new(4, 4);

Console.WriteLine(map.GetRoomAt(0, 0));
map.SetRoomAt(0, 0, RoomType.Entrance);
Console.WriteLine(map.GetRoomAt(0, 0));
Console.WriteLine(map.GetRoomAt(3, 3));

//Console.WriteLine(location);
//Console.WriteLine(player.Location);



public record Location (int row, int column);

public enum Directions { North, South, East, West }
public enum RoomType { Empty, Entrance, Fountain, MapBoundary }