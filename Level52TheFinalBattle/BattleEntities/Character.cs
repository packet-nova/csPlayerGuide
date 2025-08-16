using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public abstract class Character : IBattleEntity
    {
        public abstract string Name { get; }

        public abstract int MaxHP { get; }

        public virtual int CurrentHP { get; protected set; }

        public bool IsDead => CurrentHP <= 0;

        public virtual List<IBattleCommand> BattleCommands { get; protected set; }

        public Character()
        {
            CurrentHP = MaxHP;
            BattleCommands = [];
        }

        public void TakeDamage(int damageValue)
        {
            CurrentHP -= damageValue;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
            }
            else
            {
                Console.WriteLine($"{Name} HP is now {CurrentHP}/{MaxHP}.");
            }
        }
    }
}
