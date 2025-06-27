using Level52TheFinalBattle.Battle;

namespace Level52TheFinalBattle.Entities;

/// <summary>
/// Describes an entity in the game, such as a player, enemy, etc.
/// </summary>
public interface IGameEntity
{
    /// <summary>
    /// The name of the entity ("SKELETON", or "Player 1", etc.)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The hit points of this entity, representing its health
    /// </summary>
    public int Health { get; set; }

    /// <summary>
    /// The actions that this entity can perform
    /// </summary>
    public List<IBattleAction> Actions { get; set; }

    /// <summary>
    /// Indicates whether this entity is controlled by a human or computer
    /// </summary>
    public ControlledBy ControlledBy { get; set; }
}
