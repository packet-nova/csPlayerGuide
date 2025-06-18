public interface ICombat
{
    public string Name { get; }
    public void DoNothing()
    {
        Console.WriteLine($"{Name} did NOTHING.");
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} attacks!");
    }
}



