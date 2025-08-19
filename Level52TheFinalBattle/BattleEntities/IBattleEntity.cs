using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.BattleEntities
{
    public interface IBattleEntity
    {
        string Name { get; }
        int MaxHP { get; }
        int CurrentHP { get; }
        bool IsDead { get; }

        /// <summary>
        /// Gets the collection of battle commands available for use in combat scenarios.
        /// </summary>
        List<IBattleCommand> BattleCommands { get; }
        List<IEquippable> EquippedItems { get; }

        /// <summary>
        /// Reduces the health of the entity by the specified damage value.
        /// </summary>
        void TakeDamage(int damageValue);
        void Heal(int amount);
        void AddCommandsFromGear();
        void EquipGear(IEquippable equipment);
        void UnequipGear(IEquippable equipment);
    }
}