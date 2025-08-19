using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public abstract class Weapon : InventoryItem, IEquippable
    {
        public abstract IBattleCommand ProvidedSkill { get; }
    }
}
