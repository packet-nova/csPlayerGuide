public class MapGenerator
{

    /// <summary>
    /// Determines the dimensions of a map based on the specified size.
    /// </summary>
    /// <remarks>If an unrecognized <see cref="MapSize"/> value is provided, the method defaults to returning
    /// the dimensions for a small map (4, 4).</remarks>
    /// <param name="size">The size of the map, represented as a <see cref="MapSize"/> enumeration value.</param>
    /// <returns>A tuple containing the width (<c>x</c>) and height (<c>y</c>) of the map.  For example, a small map returns (4,
    /// 4), a medium map returns (6, 6), and a large map returns (8, 8).</returns>
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
    /// Generates a new map with specified dimensions and populates it with key locations.
    /// </summary>
    /// <remarks>The player spawn point is always set to the entrance location. The method ensures that key
    /// locations  such as the fountain and maelstrom are placed in valid positions relative to the entrance and each
    /// other.</remarks>
    /// <param name="size">The size of the map to generate, represented as a <see cref="MapSize"/> enumeration.</param>
    /// <returns>A <see cref="MapData"/> object containing the generated map and the locations of key elements,  including the
    /// entrance, player spawn point, fountain, and maelstrom.</returns>
    public MapData GenerateMap(MapSize size)
    {
        var (x, y) = GetMapSize(size);
        Map map = new Map(x, y);

        Random random = new();

        Location entranceSpawn = SpawnEntrance(map, random);
        Location fountainSpawn = SpawnFountain(map, random, entranceSpawn);
        Location playerSpawn = entranceSpawn; // Player always spawns at entrance
        Location maelstromSpawn = SpawnMaelstrom(map, random, entranceSpawn, fountainSpawn, playerSpawn);

        return new MapData
        {
            Map = map,
            EntranceSpawn = entranceSpawn,
            PlayerSpawn = playerSpawn,
            FountainSpawn = fountainSpawn,
            MaelstromSpawn = maelstromSpawn,
        };
    }
    /// <summary>
    /// Spawns an entrance in the specified map at a random location.
    /// </summary>
    /// <remarks>The entrance is placed at a random position within the bounds of the map. The method ensures
    /// that the specified location is marked as an entrance in the map.</remarks>
    /// <param name="map">The map where the entrance will be placed. Must not be null.</param>
    /// <param name="random">The random number generator used to determine the entrance's location. Must not be null.</param>
    /// <returns>A <see cref="Location"/> representing the coordinates of the entrance within the map.</returns>
    private Location SpawnEntrance(Map map, Random random)
    {
        int entranceX = random.Next(map.XSize);
        int entranceY = random.Next(map.YSize);

        map.SetRoomAt(entranceX, entranceY, RoomType.Entrance);
        return new Location(entranceX, entranceY);
    }

    /// <summary>
    /// Spawns a fountain in a random location on the map, ensuring it is not adjacent to the entrance spawn point.
    /// </summary>
    /// <param name="map">The map on which the fountain will be placed.</param>
    /// <param name="random">The random number generator used to determine the fountain's location.</param>
    /// <param name="entranceSpawn">The location of the entrance spawn point, which the fountain must not be adjacent to.</param>
    /// <returns>The <see cref="Location"/> of the newly spawned fountain.</returns>
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

    /// <summary>
    /// Spawns a maelstrom at a random location on the map, ensuring it does not overlap with specified key locations.
    /// </summary>
    /// <remarks>The maelstrom is placed in a random room on the map, excluding the rooms occupied by the
    /// entrance, fountain, or player spawn locations. The room type at the maelstrom's location is set to <see
    /// cref="RoomType.Encounter"/>.</remarks>
    /// <param name="map">The map on which the maelstrom will be spawned.</param>
    /// <param name="random">The random number generator used to determine the maelstrom's location.</param>
    /// <param name="entranceSpawn">The location of the entrance, which the maelstrom must avoid.</param>
    /// <param name="fountainSpawn">The location of the fountain, which the maelstrom must avoid.</param>
    /// <param name="playerSpawn">The player's starting location, which the maelstrom must avoid.</param>
    /// <returns>A <see cref="Location"/> representing the coordinates of the spawned maelstrom.</returns>
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
}