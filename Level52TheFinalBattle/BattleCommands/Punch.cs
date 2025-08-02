public class Punch : IBattleCommand
{
    public string DisplayName => "Punch";
    public int Damage { get; } = 1;

    public void Execute(IBattleEntity source)
    {
        Console.WriteLine($"{source.Name} does {DisplayName}.");
    }
}
