public interface IBattleCommand
{
    public ActionType ActionType { get; }
    public void Execute(IBattleEntity source);
    public string GetDisplayName(IBattleEntity entity);
}