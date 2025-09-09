using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class StoneAmarok : Monster
    {
        public override string Name => "Stone Amarok";
        public override int MaxHP => 4;
        public override int Challenge => 2;
        public override List<IBattleCommand> BattleCommands { get; protected set; } = [new Bite()];
        public override List<IDamageModifier> DamageModifiers { get; protected set; } = [new StoneArmor()];
    }
}
