using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public class Sword : Weapon
    {
        public override string Name => "Sword";
        protected override IBattleCommand CreateCommand() => new Slash();
    }
}