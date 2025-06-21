public class Attack : IBattleCommand
{
    public void Execute(IBattleEntity entity)
    {
        Console.WriteLine($"{entity.Name} attacked.");
    }

    public string GetDisplayName(IBattleEntity entity) => entity switch
    {
        TrueProgrammer => "Attack (Punch)",
        Skeleton => "Attack (Bone Crunch)",
        _ => "Attack"
    };
}