using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;

public class UnravelingAttack : IBattleCommand
{
    public ActionType Category => ActionType.Attack;

    public string Name => "Unraveling Attack";

    public bool RequiresTarget => true;

    public int BaseDamage { get; }

    public void Execute(IBattleEntity source, IBattleEntity target)
    {
        Random random = new();
        int damage = random.Next(3);
        Console.WriteLine($"{source.Name}'s {Name} deals {damage} damage to {target.Name}.");
        target.TakeDamage(damage);
    }
}

