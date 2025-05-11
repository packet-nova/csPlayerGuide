public class Debug
{
    public static bool Enabled { get; set; } = false;


    /// <summary>
    /// Prints out debug information to the console.
    /// </summary>
    public static void DebugOutput(Map map, Player player)
    {
        if (!Enabled) return;

        Console.WriteLine($"-------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"DEBUG MODE ENABLED");
        Console.ResetColor();
        Console.WriteLine($"Map X Size: {map.GetXSize()}");
        Console.WriteLine($"Map Y Size: {map.GetYSize()}");
        Console.WriteLine($"Entrance location: {MapGenerator.EntranceLocation}");
        Console.WriteLine($"Player spawn location: {MapGenerator.PlayerSpawnLocation}");
        Console.WriteLine($"Fountain location: {MapGenerator.FountainLocation}");
        Console.WriteLine($"This room is an: {map.GetRoomAt(player.Location)}");
        //Console.WriteLine($"Player alive: {!player.IsDead} | Difficulty: {options.Difficulty} | Map size {options.MapSize}");
        Console.WriteLine($"-------------------------------------------------------------------------");
    }
}