using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public interface IBattleCommand
    {
        ActionType Category { get; }
        string Name { get; }
        bool RequiresTarget { get; }
        int BaseDamage { get; }
        void Execute(IBattleEntity source, IBattleEntity target);
    }
}