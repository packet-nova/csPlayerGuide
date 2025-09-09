using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class StoneAmarok : Monster
    {
        public override string Name => "Stone Amarok";
        public override int MaxHP => 4;
        public override int Challenge => 2;

        public StoneAmarok()
        {
            DamageModifiers = [new StoneArmor()];
            BattleCommands = [new Bite()];
        }
    }
}
