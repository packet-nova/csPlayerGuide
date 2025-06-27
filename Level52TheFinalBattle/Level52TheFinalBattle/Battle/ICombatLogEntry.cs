using Level52TheFinalBattle.Entities;

namespace Level52TheFinalBattle.Battle;

public interface ICombatLogEntry
{
    /// <summary>
    /// The entity that performed the action this turn
    /// </summary>
    public IGameEntity SourceEntity { get; init; }

    /// <summary>
    /// The action performed by the <see cref="SourceEntity" /> this turn
    /// </summary>
    public IBattleAction ActionPerformed { get; init; }

    /// <summary>
    /// The target of the <see cref="ActionPerformed" /> this turn, if any
    /// </summary>
    public IGameEntity? TargetEntity { get; set; }
}

