namespace Level52TheFinalBattle.BattleCommands
{
    public class UnravelingAttack : Attack
    {
        public override string Name => "Unraveling Attack";
        public override int BaseDamage => _rng.Next(4);
        public override DamageType DamageType => DamageType.Decoding;
    }
}