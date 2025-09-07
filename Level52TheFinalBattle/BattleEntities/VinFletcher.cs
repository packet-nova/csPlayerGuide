using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class VinFletcher : Character
    {
        public override string Name => "Vin Fletcher";
        public override int MaxHP => 15;
        
        public VinFletcher()
        {
            BattleCommands = [new Punch()];
        }
    }
}
