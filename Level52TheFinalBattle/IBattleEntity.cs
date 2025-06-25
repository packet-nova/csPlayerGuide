public interface IBattleEntity
{
    public string Name { get; }
    public List<IBattleCommand> GetAvailableCommands(Battle battle);
}