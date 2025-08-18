using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Item
{
    public abstract class HealingPotion : InventoryItem, IHealing
    {
        public abstract int HealingAmount { get; }
        public abstract void Execute(IBattleEntity target);
    }
}