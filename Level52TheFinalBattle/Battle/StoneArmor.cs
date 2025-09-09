using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Battle
{
    public class StoneArmor : IDamageModifier
    {
        public string Name => "Stone Armor";
        public int ModifyDamage(IBattleEntity source, IBattleEntity target, int damage)
        {
            if (damage <= 0)
            {
                return 0;
            }
            Console.WriteLine($"{target.Name}'s {Name} reduces the damage done by 1.");
            return damage - 1;
        }
    }
}
