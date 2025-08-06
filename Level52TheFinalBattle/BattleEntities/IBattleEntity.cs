public interface IBattleEntity
{
    string Name { get; }
    int MaxHP { get; }
    int CurrentHP { get; }

/// <summary>
/// Gets the collection of battle commands available for use in combat scenarios.
/// </summary>
    List<IBattleCommand> BattleCommands { get; }
    void TakeDamage(int damageValue) { }
}