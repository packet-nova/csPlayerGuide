using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class ObjectSight : IDamageModifier
    {
        public string Name => "Object Sight";

        public int ModifyDamage(IBattleEntity source, IBattleEntity target, int damage, DamageType damageType)
        {
            if (damageType != DamageType.Decoding || damage <= 0)
            {
                return damage;
            }
            Console.WriteLine($"{target.Name}'s {Name} reduces the damage done by 2.");
            return Math.Max(0, damage - 2);
        }
    }
}
