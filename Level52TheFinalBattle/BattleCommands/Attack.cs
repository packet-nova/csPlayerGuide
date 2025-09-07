using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public abstract class Attack : IBattleCommand
    {
        protected readonly Random _rng = new();
        public ActionType Category => ActionType.Attack;
        public abstract string Name { get; }
        public bool RequiresTarget { get; } = true;
        public virtual double ChanceToHit => 1.0;
        public bool IsHit => _rng.NextDouble() < ChanceToHit;
        public abstract int BaseDamage { get; }

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            if (IsHit)
            {
                Console.WriteLine($"{source.Name}'s {Name} deals {BaseDamage} damage to {target.Name}.");
                target.TakeDamage(BaseDamage);
            }
            else
            {
                Console.WriteLine($"{source.Name}'s {Name} MISSES!");
            }
        }
    }
}
