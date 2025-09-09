using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Battle
{
    public interface IDamageModifier
    {
        string Name { get; }
        int ModifyDamage(IBattleEntity source, IBattleEntity target, int damage, DamageType damageType);
    }
}
