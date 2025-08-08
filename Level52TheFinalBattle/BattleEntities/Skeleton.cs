public class Skeleton : IBattleEntity
{
    public string Name { get; } = "Skeleton";
    public int MaxHP { get; } = 5;
    public int CurrentHP { get; private set; }
    public bool IsDead => CurrentHP <= 0;

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
        if (CurrentHP <= 0 )
        {
            CurrentHP = 0;
        }
        else
        {
            Console.WriteLine($"{Name} HP is now {CurrentHP}/{MaxHP}.");
        }
    }
}
