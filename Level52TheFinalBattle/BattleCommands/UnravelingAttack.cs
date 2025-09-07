using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleCommands
{
    public class UnravelingAttack : Attack
    {
        public override string Name => "Unraveling Attack";
        public override int BaseDamage => _rng.Next(3);
    }
}