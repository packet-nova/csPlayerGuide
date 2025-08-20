using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class BoneCrunch : IBattleCommand
    {
        public ActionType Category => ActionType.Attack;

        public string Name => "Bone Crunch";

        public bool RequiresTarget { get; } = true;

        public int BaseDamage { get; }

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            Random random = new();
            int damage = random.Next(2);
            Console.WriteLine($"{source.Name}'s {Name} deals {damage} damage to {target.Name}.");
            target.TakeDamage(damage);
        }
    }
}