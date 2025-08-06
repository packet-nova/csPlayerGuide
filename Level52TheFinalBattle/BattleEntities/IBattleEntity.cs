public interface IBattleEntity
{
    public string Name { get; }
    public int MaxHP { get; }
    public int CurrentHP { get; }

/// <summary>
/// Gets the collection of battle commands available for use in combat scenarios.
/// </summary>
    public List<IBattleCommand> BattleCommands { get; }
    public void TakeDamage(int damageValue) { }
}