using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class Zombie :  Monster
    {
        public override string Name => "Zombie";
        public override int MaxHP => 5;
        public override int Challenge => 2;

        public Zombie()
        {
            BattleCommands = [new InfectiousBite()];
        }
    }
}
