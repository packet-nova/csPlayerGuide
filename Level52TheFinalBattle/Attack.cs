public class Attack : IBattleCommand
{
    public void Execute(IBattleEntity source, IBattleEntity target)
    {
        Console.WriteLine($"{source.Name} attacked {target.Name}");
    }

    public string GetDisplayName(IBattleEntity entity) => entity switch
    {
        TrueProgrammer => "Attack (Punch)",
        Skeleton => "Attack (Bone Crunch)",
        _ => "Attack"
    };
}