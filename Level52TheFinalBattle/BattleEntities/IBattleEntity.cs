public interface IBattleEntity
{
    public string Name { get; }

    /// <summary>
    /// Retrieves a list of available battle commands based on the current state of the specified battle.
    /// </summary>
    public List<IBattleCommand> GetAvailableCommands(Battle battle);
}