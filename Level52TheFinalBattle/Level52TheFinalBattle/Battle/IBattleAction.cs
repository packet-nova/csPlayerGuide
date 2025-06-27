namespace Level52TheFinalBattle.Battle;

/// <summary>
/// Represents an action that can be performed during a battle.
/// </summary>
/// <remarks>This interface defines the basic structure for battle actions, including their name and type.
/// Implementations of this interface can represent specific actions such as attacks, defenses, or other battle-related
/// operations.</remarks>
public interface IBattleAction
{
    /// <summary>
    /// The name of the battle action, such as "Attack", "Defend", etc.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// The type of the battle action, which categorizes the action into a specific type such as "Attack", "Defend", etc.
    /// </summary>
    public BattleActionType Type { get; init; }
}

