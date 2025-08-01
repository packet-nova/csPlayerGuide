public interface IBattleEntity
{
    public string Name { get; }

/// <summary>
/// Gets the collection of battle commands available for use in combat scenarios.
/// </summary>
    public List<IBattleCommand> BattleCommands { get; }
}