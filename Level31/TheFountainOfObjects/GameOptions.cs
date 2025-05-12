public class GameOptions
{
    public MapSize MapSize { get; private set; }
    public GameDifficulty Difficulty { get; private set; }

    public GameOptions(MapSize size, GameDifficulty difficulty)
    {
        MapSize = size;
        Difficulty = difficulty;
    }

    public static GameOptions PromptGameOptions()
    {
        MapSize mapSize = PromptMapSize();
        GameDifficulty gameDifficulty = PromptGameDifficulty();
        return new GameOptions(mapSize,  gameDifficulty);
    }

    public static MapSize PromptMapSize()
    {
        while (true)
        {
            Console.Write("Choose a map size: [S]mall, (M)edium, (L)arge: ");
            string input = Console.ReadLine().ToLower().Trim();
            
            if (string.IsNullOrEmpty(input))
            {
                input = "s"; // Default to small if no input
                Console.WriteLine("Defaulting to Small map size.");
            }

            switch (input)
            {
                case "s":
                case "small":
                    return MapSize.Small;
                case "m":
                case "medium":
                    return MapSize.Medium;
                case "l":
                case "large":
                    return MapSize.Large;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Choose [S]mall, (M)edium, or (L)arge.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    public static GameDifficulty PromptGameDifficulty()
    {
        while (true)
        {
            Console.Write("Choose a difficulty: [E]asy, (M)edium, (H)ard: ");
            string input = Console.ReadLine().ToLower().Trim();

            if (string.IsNullOrEmpty(input))
            {
                input = "e"; // Default to easy if no input
                Console.WriteLine("Defaulting to Easy difficulty.");
            }

            switch (input)
            {
                case "e":
                case "easy":
                    return GameDifficulty.Easy;
                case "m":
                case "medium":
                    return GameDifficulty.Medium;
                case "h":
                case "hard":
                    return GameDifficulty.Hard;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Choose [E]asy, (M)edium, (H)ard.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}