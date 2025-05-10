public static class MapGenerator
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

    public static (Map map, (int x, int y) playerStart) GenerateMap(MapSize size) // Generates a new map. Discrete static methods for different spawners.
    {
        var (x, y) = GetMapSize(size);
        Map map = new Map(x, y);

        Random random = new();

        int pitX = random.Next(x);
        int pitY = random.Next(y);

        SpawnEntrance();
        SpawnFountain();

        (int x, int y) SpawnEntrance()
        {
            int entranceX = random.Next(x);
            int entranceY = random.Next(y);
            map.SetRoomAt(entranceX, entranceY, RoomType.Entrance);
            return (entranceX, entranceY);
        }

        //check for empty tile and spawn entrance
        void SpawnFountain()
        {
            int fountainX = random.Next(x);
            int fountainY = random.Next(y);

            if (map.GetRoomAt(fountainX, fountainY) == RoomType.Empty)
            {
                map.SetRoomAt(fountainX, fountainY, RoomType.Fountain);
            }
            else
            {
                Console.WriteLine("Error.");
            }
        }

        // check for empty tile and spawn pit
        map.SetRoomAt(pitX, pitY, RoomType.Pit);
        
        return (map, (entranceX, entranceY));
    }
}