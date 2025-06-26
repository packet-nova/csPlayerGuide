public class ColoredConsole()
{
    public static string Prompt(string question)
    {
        Console.Write(question);
        Console.ForegroundColor = ConsoleColor.Cyan;
        string coloredResponse = Console.ReadLine();
        return coloredResponse;
    }

    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }
}