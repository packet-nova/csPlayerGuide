public class Cat : IMovable
{
    public Location Location { get; set; }
    public bool IsLooted { get; set; } = false;
    public string Name { get; } = "Cat";
    public string Description { get; } = "A small, fluffy cat. It looks like it could use a good home.";
    public string SenseDescription { get; } = "You hear distant meows.";
    public bool Activated { get; private set; } = false;

    public Cat(Location location)
    {
        Location = location;
    }
    public void Move(Direction direction, Map map)
    {
        MovementHelper.Move(this, direction, map);
    }

    public void Interact()
    {
        Activated = true;
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Beep(900, 50);
        Console.Beep(1100, 50);
        Console.Beep(1300, 200);
        Console.WriteLine("You adopted a cat. Neat.");
        Console.ForegroundColor = previousColor;
    }
}
