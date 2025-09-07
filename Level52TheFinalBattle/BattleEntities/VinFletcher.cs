using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.BattleEntities
{
    public class VinFletcher : Character
    {
        public override string Name => "Vin Fletcher";
        public override int MaxHP => 15;
        
        public VinFletcher()
        {
            BattleCommands = [new Punch()];
            EquippedItems = [new VinsBow()];
            AddBattleCommandsFromGear();
        }
    }
}
