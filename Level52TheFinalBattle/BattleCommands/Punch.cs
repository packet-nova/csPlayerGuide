using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class Punch : Attack
    {
        public override string Name => "Punch";
        public override int BaseDamage => 1;

        public override DamageType Type => DamageType.Physical;
    }
}