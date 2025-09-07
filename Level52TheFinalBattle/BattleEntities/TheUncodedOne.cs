using Level52TheFinalBattle.BattleCommands;
using System.Runtime.CompilerServices;

namespace Level52TheFinalBattle.BattleEntities
{
    public class TheUncodedOne : Monster
    {
        public override string Name { get; } = "The Uncoded One";
        public override int MaxHP { get; } = 30;
        public override int Challenge => 3;
        public override List<IBattleCommand> BattleCommands { get; protected set; } = [new UnravelingAttack()];
    }
}