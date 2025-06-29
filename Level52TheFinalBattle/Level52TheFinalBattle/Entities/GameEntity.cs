using Level52TheFinalBattle.Battle;

namespace Level52TheFinalBattle.Entities;

public record GameEntity : IGameEntity
{
    private int _health;
    public required string Name { get; set; }

    public int MaxHealth { get; set; }

    public int Health
    {
        get => _health <= 0 ? 0 : _health;

        set => _health = value > 0 ? value : 0;
    }

    public bool IsDead => Health <= 0;

    public required List<IBattleAction> Actions { get; set; }

    public required ControlledBy ControlledBy { get; set; }

    // Overrides
    public override string ToString()
    {
        return Name;
    }

}

