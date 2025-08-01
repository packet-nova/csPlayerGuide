public class Attack : IBattleCommand
{
    public ActionType ActionType => ActionType.Attack;
    public void Execute(IBattleEntity source)
    {
        Console.WriteLine($"{source.Name} attacked ");
    }

    public string GetDisplayName(IBattleEntity entity) => entity switch
    {
        TrueProgrammer => "Attack (Punch)",
        Skeleton => "Attack (Bone Crunch)",
        _ => "Attack"
    };
}