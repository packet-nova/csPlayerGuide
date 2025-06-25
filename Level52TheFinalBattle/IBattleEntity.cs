public interface IBattleEntity
{
    public string Name { get; }
    public List<IBattleEntity> GetAvailableTargets(Battle battle);
    public List<IBattleCommand> GetAvailableCommands(Battle battle);
}