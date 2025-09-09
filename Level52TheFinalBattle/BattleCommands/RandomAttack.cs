namespace Level52TheFinalBattle.BattleCommands
{
    public class RandomAttack : Attack
    {
        public override string Name => "Random Attack";
        public override int BaseDamage => _rng.Next(1, 3);
        public override DamageType DamageType => DamageType.Physical;
        public override double ChanceToHit => 0.5;
    }
}
