using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public class Dagger : Weapon
    {
        public override string Name => "Dagger";
        protected override IBattleCommand CreateCommand() => new Stab();
    }
}
