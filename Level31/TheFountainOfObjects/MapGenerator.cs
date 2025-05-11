using System.ComponentModel;

public class MapGenerator
{

    public static (int x, int y) EntranceLocation { get; private set; }
    public static (int x, int y) FountainLocation { get; private set; }
    public static (int x, int y) PlayerSpawnLocation { get; private set; }

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
    /// <param name="size"></param>
    /// <returns></returns>
    public static Map GenerateMap(MapSize size)
    {
        var (x, y) = GetMapSize(size);
        Map map = new Map(x, y);

        Random random = new();

        int pitX = random.Next(x);
        int pitY = random.Next(y);

        (int entranceX, int entranceY) = SpawnEntrance();
        (int fountainX, int fountainY) = SpawnFountain();
        (int playerSpawnX, int playerSpawnY) = SpawnPlayer();
        //SpawnEntrance();
        //SpawnFountain();

        (int x, int y) SpawnEntrance()
        {
            int entranceX = random.Next(x);
            int entranceY = random.Next(y);
            map.SetRoomAt(entranceX, entranceY, RoomType.Entrance);
            EntranceLocation = (entranceX, entranceY);
            PlayerSpawnLocation = EntranceLocation;
            return (entranceX, entranceY);
        }

        //check for empty tile and spawn entrance
        (int x, int y) SpawnFountain()
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
            FountainLocation = (fountainX, fountainY);
            return (fountainX, fountainY);
        }

        (int x, int y) SpawnPlayer()
        {
            //Currently spawns player at entrance
            //Add future logic to decouple player spawn to support other map types or extra levels.
            PlayerSpawnLocation = EntranceLocation;
            return PlayerSpawnLocation;
        }

        // check for empty tile and spawn pit
        map.SetRoomAt(pitX, pitY, RoomType.Pit);
        
        return map;
        //return (map, (entranceX, entranceY));
    }
}