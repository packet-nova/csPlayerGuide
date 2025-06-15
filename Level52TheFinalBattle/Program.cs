Game game = new();
game.Run();

public class TrueProgrammer : ICombat
{
    public string Name { get; private set; }

    public TrueProgrammer(string name)
    {
        Name = name;
    }
}

public class Skeleton : ICombat
{
    public string Name { get; init; }

    public Skeleton(string name)
    {
        Name = name;
    }
}

public interface ICombat
{
    public string Name { get; }
    public void DoNothing()
    {
        Console.WriteLine($"{Name} did NOTHING.");
        Console.WriteLine();
    }
}