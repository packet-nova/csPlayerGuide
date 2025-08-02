public interface IBattleCommand
{
    public string DisplayName { get; }
    public void Execute(IBattleEntity source);
}