using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public interface IEquippable
    {
        string Name { get; }
        IBattleCommand ProvidedSkill { get; }
    }
}
