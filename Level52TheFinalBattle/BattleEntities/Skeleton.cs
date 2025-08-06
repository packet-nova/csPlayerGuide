public class Skeleton : IBattleEntity
{
    public string Name { get; } = "Skeleton";
    public int MaxHP { get; } = 5;
    public int CurrentHP { get; private set; }

    public Skeleton()
    {
        CurrentHP = MaxHP;
    }

    public List<IBattleCommand> BattleCommands { get; } =
    [
       new BoneCrunch()
    ];

    public void TakeDamage(int damageValue)
    {
        CurrentHP -= damageValue;
        Console.WriteLine($"{Name} HP is now {CurrentHP}/{MaxHP}.");
    }

}
