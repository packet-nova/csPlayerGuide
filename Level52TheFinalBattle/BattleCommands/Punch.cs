public class Punch : IBattleCommand
{
    public ActionType Category { get; } = ActionType.Attack;
    public string DisplayName => "Punch";
    public int BaseDamage { get; } = 1;

    public void Execute(IBattleEntity source)
    {
        Console.WriteLine($"{source.Name}'s {DisplayName} does {BaseDamage} damage.");
    }
}
