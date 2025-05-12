public class MapGenerator
{
    public static Location EntranceLocation { get; private set; }
    public static Location FountainLocation { get; private set; }
    public static Location PlayerSpawnLocation { get; private set; }
    public static Location CatLocation { get; private set; }
    public static Location MaelstromLocation { get; private set; }

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

    public static void TrySpawnAt(MapSize size, RoomType roomType)
    {
        bool IsEmpty = false;
    }
    /// <summary>
    ///Generates a new map. Discrete static methods for different spawners.
    /// </summary>
    public static Map GenerateMap(MapSize size)
    {
        var (x, y) = GetMapSize(size);
        Map map = new Map(x, y);

        Random random = new();

        Location entranceLocation = SpawnEntrance();
        Location fountainLocation = SpawnFountain();
        Location playerSpawnLocation = SpawnPlayer();
        Location catLocation = SpawnCat();
        Location maelstromLocation = SpawnMaelstrom();

        //Spawner Methods

        //Check for empty tile and spawn entrance
        Location SpawnEntrance()
        {
            int entranceX = random.Next(x);
            int entranceY = random.Next(y);
            map.SetRoomAt(entranceX, entranceY, RoomType.Entrance);
            EntranceLocation = new(entranceX, entranceY);
            return EntranceLocation;
        }

        // Spawns a fountain at the first random location only if it is RoomType.Empty
        Location SpawnFountain()
        {
            int fountainX = random.Next(x);
            int fountainY = random.Next(y);

            if (map.GetRoomAt(new(fountainX, fountainY)) == RoomType.Empty)
            {
                map.SetRoomAt(fountainX, fountainY, RoomType.Fountain);
            }
            else
            {
                Console.WriteLine("Error.");
            }
            FountainLocation = new(fountainX, fountainY);
            return FountainLocation;
        }

        //Currently spawns player at entrance
        //Add future logic to decouple player spawn to support other map types or extra levels.
        Location SpawnPlayer()
        {
            PlayerSpawnLocation = EntranceLocation;
            return PlayerSpawnLocation;
        }

        Location SpawnMaelstrom()
        {
            int maelstromX = random.Next(x);
            int maelstromY = random.Next(y);
            MaelstromLocation = new(maelstromX, maelstromY);
            return CatLocation;
        }

        Location SpawnCat()
        {
            int catX = random.Next(x);
            int catY = random.Next(y);
            CatLocation = new(catX, catY);
            return CatLocation;
        }

        //Ignore
        //Location SpawnPit()
        //{
        //    int pitX = random.Next(x);
        //    int pitY = random.Next(y);
        //    map.SetRoomAt(pitX, pitY, RoomType.Pit);
        //}

        return map;
    }
}