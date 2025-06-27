using Level52TheFinalBattle.Entities;

using System.Text;

namespace Level52TheFinalBattle.Battle;

public record CombatLogEntry : ICombatLogEntry
{
    /// <inheritdoc cref="ICombatLogEntry.SourceEntity" />
    public required IGameEntity SourceEntity { get; init; }

    /// <inheritdoc cref="ICombatLogEntry.TargetEntity" />
    public IGameEntity? TargetEntity { get; set; }

    /// <inheritdoc cref="ICombatLogEntry.ActionPerformed" />
    public required IBattleAction ActionPerformed { get; init; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"{SourceEntity.Name} did ");
        sb.Append(ActionPerformed);

        if (TargetEntity != null)
        {
            sb.Append($" to {TargetEntity.Name}");
        }

        sb.Append(".");

        return sb.ToString();
    }
}