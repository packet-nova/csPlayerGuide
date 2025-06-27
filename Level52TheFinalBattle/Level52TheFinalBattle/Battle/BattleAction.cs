namespace Level52TheFinalBattle.Battle;

public record BattleAction : IBattleAction
{
    public required string Name { get; init; }

    public required BattleActionType Type { get; init; }

    /// <summary>
    /// A "nothing" action that can be used when no action is desired.
    /// </summary>
    public static readonly BattleAction Nothing = new() { Name = "Nothing", Type = BattleActionType.Nothing };

    // Overrides
    public override string ToString()
    {
        return $"{Name}";
    }
}
