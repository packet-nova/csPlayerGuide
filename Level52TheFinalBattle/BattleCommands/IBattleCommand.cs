public interface IBattleCommand
{
    public ActionType Category { get; }
    public string DisplayName { get; }
    public bool RequiresTarget { get; }
    public void Execute();
}