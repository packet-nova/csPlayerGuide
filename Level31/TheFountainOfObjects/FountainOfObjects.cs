public class FountainOfObjects
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public static bool Activated { get; private set; } = false;

    public static void Interact()
    {
        Activated = true;
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Beep(900, 50);
        Console.Beep(1100, 50);
        Console.Beep(1300, 200);
        Console.WriteLine("The sound of rushing water overwhelms you. You've restored the Fountain of Objects! Head to the exit!");
        Console.ForegroundColor = previousColor;
    }
}