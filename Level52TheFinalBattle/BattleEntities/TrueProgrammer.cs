public class TrueProgrammer : IBattleEntity
{
    public string Name { get; private set; }
    public int MaxHP { get; } = 25;
    public int CurrentHP { get; private set; }
    public bool IsDead => CurrentHP <= 0;

    public TrueProgrammer(string name)
    {
        Name = name;
        CurrentHP = MaxHP;
    }

    public List<IBattleCommand> BattleCommands { get; } =
    [
       new Punch()
    ];

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
