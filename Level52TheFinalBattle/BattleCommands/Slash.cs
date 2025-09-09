using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class Slash : Attack
    {
        public override string Name => "Slash";
        public override int BaseDamage => 2;
        public override DamageType DamageType => DamageType.Physical;
    }
}
