public class TrueProgrammer : IBattleEntity
{
    public string Name { get; private set; }
    public int MaxHP { get; } = 25;
    public int CurrentHP { get; private set; }

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
        Console.WriteLine($"{Name} HP is now {CurrentHP}/{MaxHP}.");
    }
}
