using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class TheUncodedOne : Monster
    {
        public override string Name { get; } = "The Uncoded One";
        public override int MaxHP { get; } = 30;
        public override int Challenge => 3;

        public TheUncodedOne()
        {
            BattleCommands = [new UnravelingAttack()];
        }
    }
}