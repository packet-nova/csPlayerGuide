public static class GameUI
{
    public static void TitleScreen()
    {
        Console.Write("""
            The Fountain of Objects

            You've wandered into a dark cave to find and reactivate the Fountain of Objects.
            Navigate to locate and activate the fountain.
            Then make your way to the exit.
            
            Press any key to continue, and good luck!
            """);
        Console.ReadKey();
        Console.Clear();
        for (int i = 0; i < 5; i++)
        {
            Console.Write(". ");
            Thread.Sleep(400);
        }
        Console.Clear();
    }

    public static void PlayerStatus(Map map, Player player)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"-------------------------------------------------------------------------");
        Console.WriteLine($"You are in the room at {player.Location}.");
        map.GetRoomDescription(player.X, player.Y);
        Console.ForegroundColor = previousColor;
    }

    public static void WinScreen()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You activated the fountain and made a safe exit. You win!");
        Console.ResetColor();
    }

    public static void HelpMessage()
    {
        Console.WriteLine("""
            You can navigate the caverns by using 4 cardinal directions: (N)orth, (S)outh, (E)ast, and (W)est.
            Watch out for traps and pitfalls, and there may be monsters lurking to ambush you.
            """);
        Console.ReadKey();
        Console.Clear();
    }
}