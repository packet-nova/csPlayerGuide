public class MapGenerator
{
    public static (int x, int y) GetMapSize(MapSize size)
    {
        return size switch
        {
            MapSize.Small => (4, 4),
            MapSize.Medium => (6, 6),
            MapSize.Large => (8, 8),
            _ => (4, 4),
        };
    }

    public static (Map map, (int x, int y) playerStart) GenerateMap(MapSize size) // Generates a new map. Player spawn is always entrance.
    {
        var (x, y) = GetMapSize(size);
        Map map = new Map(x, y);

        Random random = new();
        int entranceX = random.Next(x);
        int entranceY = random.Next(y);

        map.SetRoomAt(entranceX, entranceY, RoomType.Entrance);
        map.SetRoomAt(0, 2, RoomType.Fountain);

        return (map, (entranceX, entranceY));
    }
}