public interface IBattleCommand
{
    public void Execute(IBattleEntity entity);
    public string GetDisplayName(IBattleEntity entity);
}