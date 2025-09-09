using Level52TheFinalBattle.Battle;
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

        List<IBattleCommand> BattleCommands { get; }
        List<IEquippable> EquippedItems { get; }
        List<IDamageModifier> DamageModifiers { get; }


        void TakeDamage(int damageValue);
        void Heal(int amount);
        void AddBattleCommandsFromGear();
        void EquipGear(IEquippable equipment, BattleParty party);
        void UnequipGear(IEquippable equipment, BattleParty party);
    }
}