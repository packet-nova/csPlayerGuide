namespace Level52TheFinalBattle.BattleCommands
{
    public class QuickShot : Attack
    {
        public override string Name => "Quick Shot";
        public override int BaseDamage => 3;
        public override DamageType DamageType => DamageType.Physical;
        public override double ChanceToHit => .5;
    }
}
