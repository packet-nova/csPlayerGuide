using Level52TheFinalBattle.Battle;

namespace Level52TheFinalBattle.Entities;

public record GameEntity : IGameEntity
{
    public required string Name { get; set; }

    public int Health { get; set; }

    public required List<IBattleAction> Actions { get; set; }

    public required ControlledBy ControlledBy { get; set; }

    // Overrides
    public override string ToString()
    {
        return Name;
    }
}

