public interface IBattleEntity
{
    string Name { get; }
    int MaxHP { get; }
    int CurrentHP { get; }
    bool IsDead { get; }

    event Action<IBattleEntity> Died;


    /// <summary>
    /// Gets the collection of battle commands available for use in combat scenarios.
    /// </summary>
    List<IBattleCommand> BattleCommands { get; }

    /// <summary>
    /// Reduces the health of the entity by the specified damage value.
    /// </summary>
    void TakeDamage(int damageValue) { }
}