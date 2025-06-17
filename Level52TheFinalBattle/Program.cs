Game game = new();

game.Run();

public interface ICombat
{
    public string Name { get; }
    public void DoNothing()
    {
        Console.WriteLine($"{Name} did NOTHING.");
        Console.WriteLine();
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} attacks!");
        Console.WriteLine();
    }
}



