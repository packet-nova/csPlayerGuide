using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Battle
{
    public interface IDamageModifier
    {
        string Name { get; }
        int ModifyDamage(IBattleEntity source, IBattleEntity target, int damage);
    }
}
