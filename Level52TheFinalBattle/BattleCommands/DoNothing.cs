public class DoNothing : IBattleCommand
{
    public ActionType Category => ActionType.Nothing;

    public string DisplayName => "Do Nothing";

    public void Execute(IBattleEntity source)
    {
        Console.WriteLine($"{source.Name} did NOTHING.");
    }
}