public interface IBattleCommand
{
    public ActionType Category { get; }
    public string DisplayName { get; }
    public void Execute(IBattleEntity source);
}