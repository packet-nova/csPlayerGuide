using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Item
{
    public interface IHealing
    {
        int HealingAmount { get; }

        void Execute(IBattleEntity target);
    }
}
