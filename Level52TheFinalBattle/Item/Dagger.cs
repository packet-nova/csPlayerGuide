using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public class Dagger : Weapon
    {
        public override IBattleCommand ProvidedSkill => new Stab();

        public override string Name => "Dagger";
    }
}
