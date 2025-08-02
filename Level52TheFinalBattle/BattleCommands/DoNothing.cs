public class DoNothing : IBattleCommand
{
    public string DisplayName => "Do Nothing";

    public void Execute(IBattleEntity source)
    {
        Console.WriteLine($"{source.Name} did NOTHING.");
    }
}