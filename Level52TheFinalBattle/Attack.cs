public class Attack : IBattleCommand
{
    private IBattleEntity _target;

    public Attack(IBattleEntity target)
    {
        _target = target;
    }
    public void Execute(IBattleEntity source)
    {
        Console.WriteLine($"{source.Name} attacked {_target.Name}");
    }

    public string GetDisplayName(IBattleEntity entity) => entity switch
    {
        TrueProgrammer => "Attack (Punch)",
        Skeleton => "Attack (Bone Crunch)",
        _ => "Attack"
    };
}