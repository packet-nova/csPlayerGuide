using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public interface IDamageModifier
    {
        string Name { get; }
        int ModifyDamage(IBattleEntity source, IBattleEntity target, int damage, DamageType damageType);
    }
}
