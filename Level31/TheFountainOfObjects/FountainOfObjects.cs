public class FountainOfObjects
{
    public Location Location { get; set; }
    public bool Activated { get; private set; } = false;

    public FountainOfObjects(Location location)
    {
        Location = location;
    }

    public void Interact()
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