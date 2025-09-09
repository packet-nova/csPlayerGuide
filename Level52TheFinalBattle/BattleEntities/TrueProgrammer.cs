using Level52TheFinalBattle.Battle;
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
            EquippedItems = [new Sword()];
            BattleCommands = [new Punch()];
            DamageModifiers = [new ObjectSight()];
            AddBattleCommandsFromGear();
        }
    }
}