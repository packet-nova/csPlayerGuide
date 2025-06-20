public class Attack : IBattleCommand
{
    public void Execute(IBattleEntity entity)
    {
        Console.WriteLine($"{entity.Name} attacked.");
    }
}