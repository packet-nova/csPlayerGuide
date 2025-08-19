using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public class Sword : Weapon
    {
        public override string Name => "Sword";
        public override IBattleCommand ProvidedSkill => new Slash();
    }
}