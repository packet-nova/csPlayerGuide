using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class QuickShot : Attack
    {
        public override string Name => "Quick Shot";
        public override int BaseDamage => 3;
        public override double ChanceToHit => .5;
    }
}
