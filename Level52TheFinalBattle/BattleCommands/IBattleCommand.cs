public interface IBattleCommand
{
    public ActionType Category { get; }
    public void Execute(IBattleEntity source);
    public string GetDisplayName(IBattleEntity entity);
}