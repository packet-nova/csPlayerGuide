using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.BattleEntities
{
    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override int MaxHP { get; } = 25;
        public TrueProgrammer(string name)
        {
            Name = name;
            EquippedItems.Add(new Sword());
            BattleCommands = [new Punch()];
            AddBattleCommandsFromGear();
        }
    }
}