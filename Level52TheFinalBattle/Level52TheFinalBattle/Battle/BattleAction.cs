using Level52TheFinalBattle.Entities;

namespace Level52TheFinalBattle.Battle;

public record BattleAction : IBattleAction
{
    public required string Name { get; init; }

    public required BattleActionType Type { get; init; }

    /// <summary>
    /// A "nothing" action that can be used when no action is desired.
    /// </summary>
    public static readonly BattleAction Nothing = new() { Name = "Nothing", Type = BattleActionType.Nothing };

    public int GetHealthModifier()
    {
        var rng = new Random();

        return Name switch
        {
            "PUNCH" => -1,
            "BONE CRUNCH" => -rng.Next(2),
            _ => 0
        };
    }

    public void Execute(IGameEntity target)
    {
        target.Health += GetHealthModifier();
    }

    // Overrides
    public override string ToString()
    {
        return $"{Name}";
    }
}
