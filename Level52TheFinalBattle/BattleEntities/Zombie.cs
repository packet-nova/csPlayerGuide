using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class Zombie :  Character
    {
        public override string Name => "Zombie";
        public override int MaxHP => 5;

        public Zombie()
        {
            BattleCommands = [new InfectiousBite()];
        }
    }
}
