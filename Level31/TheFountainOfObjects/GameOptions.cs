public class GameOptions
{
    //public int MapRows { get; private set; }
    //public int MapColumns { get; private set; }
    public MapSize MapSize { get; private set; }
    public GameDifficulty Difficulty { get; private set; }

    public GameOptions(MapSize size)
    {
        MapSize = size;
        //Difficulty = difficulty;
    }

    public static MapSize PromptMapSize()
    {
        while (true)
        {
            Console.Write("Pick a map size: (S)mall, (M)edium, (L)arge: ");
            string input = Console.ReadLine().ToLower().Trim();
            
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
                    Console.WriteLine("Invalid input. Choose (S)mall, (M)edium, or (L)arge.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}