public interface IBattleCommand
{
    public void Execute(IBattleEntity source);
    public string GetDisplayName(IBattleEntity entity);
}