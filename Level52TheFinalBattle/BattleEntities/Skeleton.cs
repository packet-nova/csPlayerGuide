using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class Skeleton : Character
    {
        public override string Name { get; } = "Skeleton";
        public override int MaxHP { get; } = 1;

        public Skeleton()
        {
            BattleCommands = [new BoneCrunch()];
        }
    }
}