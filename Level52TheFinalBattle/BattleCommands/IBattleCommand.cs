public interface IBattleCommand
{
    public ActionType Category { get; }
    public string DisplayName { get; }
    public bool RequiresTarget { get; }
    public int BaseDamage { get; }
    public void Execute();
}