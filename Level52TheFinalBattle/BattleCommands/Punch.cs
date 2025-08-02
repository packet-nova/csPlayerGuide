public class Punch : IBattleCommand
{
    public ActionType Category { get; } = ActionType.Attack;
    public string DisplayName => "Punch";
    public int BaseDamage { get; } = 1;
    public bool RequiresTarget { get; } = true;

    public void Execute() { }
}
