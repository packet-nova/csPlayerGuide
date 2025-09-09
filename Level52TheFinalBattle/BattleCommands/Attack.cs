using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public abstract class Attack : IBattleCommand
    {
        public abstract string Name { get; }
        public abstract int BaseDamage { get; }
        public abstract DamageType DamageType { get; }

        protected readonly Random _rng = new();
        public virtual double ChanceToHit => 1.0;
        public ActionType Category => ActionType.Attack;
        public bool RequiresTarget { get; } = true;
        public bool IsHit => _rng.NextDouble() < ChanceToHit;

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            int damage = BaseDamage;

            if (IsHit)
            {
                foreach (var modifiers in target.DamageModifiers)
                {
                    damage = modifiers.ModifyDamage(source, target, damage, DamageType);
                }
                Console.WriteLine($"{source.Name}'s {Name} deals {damage} {DamageType} damage to {target.Name}.");
                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{source.Name}'s {Name} MISSES!");
            }
        }
    }
}