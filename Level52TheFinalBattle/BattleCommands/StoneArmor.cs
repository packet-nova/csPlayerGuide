using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class StoneArmor : IDamageModifier
    {
        public string Name => "Stone Armor";
        public int ModifyDamage(IBattleEntity source, IBattleEntity target, int damage, DamageType damageType)
        {
            if (damageType != DamageType.Physical || damage <= 0)
            {
                return damage;
            }
            Console.WriteLine($"{target.Name}'s {Name} reduces the damage done by 1.");
            return damage - 1;
        }
    }
}
