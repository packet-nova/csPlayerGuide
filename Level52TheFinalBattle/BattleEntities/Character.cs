using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.BattleEntities
{
    public abstract class Character : IBattleEntity
    {
        public abstract string Name { get; }
        public abstract int MaxHP { get; }
        public virtual int CurrentHP { get; protected set; }
        public bool IsDead => CurrentHP <= 0;
        public virtual List<IEquippable> EquippedItems { get; protected set; } = [];
        public virtual List<IBattleCommand> BattleCommands { get; protected set; } = [];

        public Character()
        {
            CurrentHP = MaxHP;
        }

        public void TakeDamage(int damageValue)
        {
            CurrentHP -= damageValue;
            CurrentHP = CurrentHP < 0 ? 0 : CurrentHP;
        }

        public void Heal(int healingValue)
        {
            CurrentHP += healingValue;
            CurrentHP = CurrentHP > MaxHP ? MaxHP : CurrentHP;
        }

        public void AddBattleCommandsFromGear()
        {
            foreach (IEquippable equipment in EquippedItems)
            {
                if (!BattleCommands.Contains(equipment.ProvidedCommand))
                {
                    BattleCommands.Add(equipment.ProvidedCommand);
                }
            }
        }

        public void EquipGear(IEquippable equipment)
        {
            EquippedItems.Add(equipment);

            if (!BattleCommands.Contains(equipment.ProvidedCommand))
            {
                BattleCommands.Add(equipment.ProvidedCommand);
            }
        }

        public void UnequipGear(IEquippable equipment)
        {
            EquippedItems.Remove(equipment);
            BattleCommands.Remove(equipment.ProvidedCommand);
        }
    }
}
