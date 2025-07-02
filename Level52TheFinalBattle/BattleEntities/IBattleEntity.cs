public interface IBattleEntity
{
    public string Name { get; }

    /// <summary>
    /// All available battle commands this entity can perform.
    /// </summary>
    public List<IBattleCommand> BattleCommands { get; }

    /// <summary>
    /// Retrieves a list of available battle commands based on the current state of the specified battle.
    /// </summary>

}