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

        /// <summary>
        /// Adds unique battle commands provided by equipped items to the list of available battle commands.
        /// </summary>
        /// <remarks>This method iterates through all equipped items and adds their provided skills to the
        /// <see cref="BattleCommands"/> collection if they are not already present.  It ensures that each skill is
        /// added only once.</remarks>
        public void AddBattleCommandsFromGear()
        {
            foreach (IEquippable equipment in EquippedItems)
            {
                if (!BattleCommands.Contains(equipment.ProvidedSkill))
                {
                    BattleCommands.Add(equipment.ProvidedSkill);
                }
            }
        }

        /// <summary>
        /// Equips the specified gear item and updates the character's equipped items and battle commands.
        /// </summary>
        /// <remarks>This method adds the specified gear item to the list of equipped items. If the gear
        /// provides a skill  that is not already in the list of battle commands, the skill is also added to the battle
        /// commands.</remarks>
        /// <param name="equipment">The gear item to equip. Must implement <see cref="IEquippable"/>.</param>
        public void EquipGear(IEquippable equipment)
        {
            EquippedItems.Add(equipment);

            if (!BattleCommands.Contains(equipment.ProvidedSkill))
            {
                BattleCommands.Add(equipment.ProvidedSkill);
            }
        }

        /// <summary>
        /// Unequips the specified gear and removes its associated skill from the battle commands.
        /// </summary>
        /// <remarks>This method removes the specified gear from the equipped items collection and also
        /// removes  the skill provided by the gear from the battle commands. Ensure that the provided  <paramref
        /// name="equipment"/> is currently equipped before calling this method.</remarks>
        /// <param name="equipment">The gear to unequip. Must implement the <see cref="IEquippable"/> interface.</param>
        public void UnequipGear(IEquippable equipment)
        {
            EquippedItems.Remove(equipment);
            BattleCommands.Remove(equipment.ProvidedSkill);
        }
    }
}
