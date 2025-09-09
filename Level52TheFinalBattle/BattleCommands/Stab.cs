namespace Level52TheFinalBattle.BattleCommands
{
    internal class Stab : Attack
    {
        public override string Name => "Stab";
        public override int BaseDamage => 1;
        public override DamageType DamageType => DamageType.Physical;
    }
}