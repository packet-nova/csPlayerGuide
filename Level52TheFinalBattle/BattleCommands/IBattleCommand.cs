public interface IBattleCommand
{
    ActionType Category { get; }
    string DisplayName { get; }
    bool RequiresTarget { get; }
    int BaseDamage { get; }
    void Execute(IBattleEntity source, IBattleEntity target);
}