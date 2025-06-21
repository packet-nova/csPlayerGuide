public class DoNothing : IBattleCommand
{
    public void Execute(IBattleEntity entity)
    {
        Console.WriteLine($"{entity.Name} did NOTHING.");
    }

    public string GetDisplayName(IBattleEntity entity) => "Do Nothing";
}