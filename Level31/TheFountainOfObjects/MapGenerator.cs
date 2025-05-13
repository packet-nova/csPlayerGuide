public class MapGenerator
{
    public (int x, int y) GetMapSize(MapSize size)
    {
        return size switch
        {
            MapSize.Small => (4, 4),
            MapSize.Medium => (6, 6),
            MapSize.Large => (8, 8),
            _ => (4, 4),
        };
    }

    /// <summary>
    ///Generates a new map. Discrete static methods for different spawners.
    /// </summary>
    /// 
    public MapData GenerateMap(MapSize size)
    {
        var (x, y) = GetMapSize(size);
        Map map = new Map(x, y);

        Random random = new();

        Location entranceSpawn = SpawnEntrance(map, random);
        Location fountainSpawn = SpawnFountain(map, random, entranceSpawn);
        Location playerSpawn = entranceSpawn; // Player always spawns at entrance
        Location maelstromSpawn = SpawnMaelstrom(map, random, entranceSpawn, fountainSpawn, playerSpawn);
        Location catSpawn = SpawnCat(map, random);

        return new MapData
        {
            Map = map,
            EntranceSpawn = entranceSpawn,
            PlayerSpawn = playerSpawn,
            FountainSpawn = fountainSpawn,
            MaelstromSpawn = maelstromSpawn,
            CatSpawn = catSpawn
        };
    }

    private Location SpawnEntrance(Map map, Random random)
    {
        int entranceX = random.Next(map.XSize);
        int entranceY = random.Next(map.YSize);

        map.SetRoomAt(entranceX, entranceY, RoomType.Entrance);
        return new Location(entranceX, entranceY);
    }

    // Spawns a fountain at the first random location only if it is RoomType.Empty
    private Location SpawnFountain(Map map, Random random, Location entranceSpawn)
    {
        int fountainX;
        int fountainY;

        do
        {
            fountainX = random.Next(map.XSize);
            fountainY = random.Next(map.YSize);
        }
        while (Math.Abs(fountainX - entranceSpawn.x) <= 1 ||
               Math.Abs(fountainY - entranceSpawn.y) <= 1);

        map.SetRoomAt(fountainX, fountainY, RoomType.Fountain);
        return new Location(fountainX, fountainY);
    }

    private Location SpawnMaelstrom(Map map, Random random, Location entranceSpawn, Location fountainSpawn, Location playerSpawn)
    {
        int maelstromX;
        int maelstromY;

        do
        {
            maelstromX = random.Next(map.XSize);
            maelstromY = random.Next(map.YSize);
        }
        while ((maelstromX == entranceSpawn.x && maelstromY == entranceSpawn.y)
        || (maelstromX == fountainSpawn.x && maelstromY == fountainSpawn.y)
        || (maelstromX == playerSpawn.x && maelstromY == playerSpawn.y));

        map.SetRoomAt(maelstromX, maelstromY, RoomType.Encounter);
        return new Location(maelstromX, maelstromY);
    }

    private Location SpawnCat(Map map, Random random)
    {
        int catX = random.Next(map.XSize);
        int catY = random.Next(map.YSize);

        map.SetRoomAt(catX, catY, RoomType.Encounter);
        return new Location (catX, catY);
    }

    //Ignore
    //Location SpawnPit()
    //{
    //    int pitX = random.Next(x);
    //    int pitY = random.Next(y);
    //    map.SetRoomAt(pitX, pitY, RoomType.Encounter);
    //}

}