/// <summary>
/// Describes an entity in the game, such as a player, enemy, etc.
/// </summary>
public interface IGameEntity 
{
    /// <summary>
    /// The name of the entity ("SKELETON", or "Player 1", etc)
    /// </summary>
    public string Name { get; set; }

    public int Health { get; set; }

    /// <summary>
    /// The actions that this entity can perform
    /// </summary>
    public List<IBattleAction> Actions { get; set; }
    public ControlledBy ControlledBy { get; set; }
}

public class GameEntity : IGameEntity
{
    public string Name { get; set; }

    public int Health { get; set; }

    public List<IBattleAction> Actions { get; set; }
    public ControlledBy ControlledBy { get; set; }
}

/// <summary>
/// Represents an action that can be performed during a battle.
/// </summary>
/// <remarks>This interface defines the basic structure for battle actions, including their name and type.
/// Implementations of this interface can represent specific actions such as attacks, defenses, or other battle-related
/// operations.</remarks>
public interface IBattleAction
{
    public string Name { get; init; }

    public BattleActionType Type { get; init; }
}

public class BattleAction
{
    public string Name { get; init; }

    public BattleActionType Type { get; init; }
}

public enum BattleActionType
{
    Nothing,

    Attack,
}

public enum ControlledBy
{
    Computer,

    Human
}

public class GameBattle
{
    public List<IGameEntity> HeroParty { get; set; }

    public List<IGameEntity> EnemyParty { get; set; }

    public List<CombatLogEntry> CombatLogEntry { get; set; }

}

public class CombatLogEntry
{
    public IGameEntity SourceEntity { get; set; }
    public IGameEntity? TargetEntity { get; set; }
    public IBattleAction ActionPerformed { get; set; }
}