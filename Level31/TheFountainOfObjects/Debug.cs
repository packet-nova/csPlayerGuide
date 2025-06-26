public class Debug
{
    public static bool Enabled { get; set; } = false;


    /// <summary>
    /// Prints out debug information to the console.
    /// </summary>
    public static void DebugOutput(Game game)
    {
        if (!Enabled) return;

        Map map = game.MapData.Map;
        MapData mapData = game.MapData;
        Player player = game.Player;

        Console.WriteLine($"-------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"DEBUG MODE ENABLED");
        Console.ResetColor();
        Console.WriteLine($"Map X Size: {map.XSize}");
        Console.WriteLine($"Map Y Size: {map.YSize}");
        Console.WriteLine($"Entrance: {mapData.EntranceSpawn}");
        Console.WriteLine($"Player spawn: {mapData.PlayerSpawn}");
        Console.WriteLine($"Fountain spawn: {mapData.FountainSpawn}");
        Console.WriteLine($"Maelstrom spawn: {mapData.MaelstromSpawn}");
        Console.WriteLine($"This room is an: {map.GetRoomAt(player.Location)}");
        Console.WriteLine($"-------------------------------------------------------------------------");
    }
}