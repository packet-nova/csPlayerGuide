public class Character : IBattleEntity
{
    public virtual string Name { get; }

    public virtual int MaxHP { get; }

    public virtual int CurrentHP {get; protected set;}

    public bool IsDead => CurrentHP <= 0;

    public virtual List<IBattleCommand> BattleCommands { get; protected set; }

    public Character()
    {
        CurrentHP = MaxHP;
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