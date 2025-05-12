public class GameUI
{
    public static void TitleScreen()
    {
        Console.Write("""
            The Fountain of Objects
            -----------------------

            You've wandered into a dark cave to find and reactivate the Fountain of Objects.
            Navigate to locate and activate the fountain.
            Then make your way to the exit.

            Press (h) for help.
            
            Press any key to continue, and good luck!
            """);
        Console.ReadKey();
        LoadingDots();
        Console.Clear();
    }

    public static void PlayerStatus(Player player, Map map)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"-------------------------------------------------------------------------");
        Console.WriteLine($"You are in the room at {player.Location}");
        Console.WriteLine($"Level: {player.PlayerLevel} Status: {(player.IsDead ? "Dead" : "Alive")} | HP: {player.CurrentHealth}/{player.MaxHealth}");
        map.GetRoomDescription(player.Location);
        Console.ResetColor();
        Console.WriteLine($"-------------------------------------------------------------------------");
        // debug ouput line - only displays if Debug is enabled in Debug class
        Debug.DebugOutput(map, player);
        Console.ForegroundColor = previousColor;
    }

    public static void WinScreen()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You activated the fountain and made a safe exit. You win!");
        Console.ResetColor();
    }

    public static void LoseScreen()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have died. Game over.");
        Console.ResetColor();
    }

    public static void HelpMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("""
            Help:
            You can navigate the caverns by using 4 cardinal directions: (N)orth, (S)outh, (E)ast, and (W)est.
            You can (L)ook to see your surroundings.
            (A)ctivate the fountain when you locate it.
            Watch out for deadly maelstroms. You are not equipped enough to fight these.
            """);
        Console.ResetColor();
    }

    public static void LoadingDots(int countOfDots = 5, int delay = 5)
    {
        for (int i = 0; i < countOfDots; i++)
        {
            Console.Write(". ");
            Thread.Sleep(delay);
        }
        Console.Clear();
    }
}