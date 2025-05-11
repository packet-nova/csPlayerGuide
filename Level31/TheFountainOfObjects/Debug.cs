public class Debug
{
    public static bool Enabled { get; set; } = true;


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
        Console.WriteLine($"Player spawn location: {MapGenerator.PlayerSpawn}");
        Console.WriteLine($"-------------------------------------------------------------------------");
    }
}