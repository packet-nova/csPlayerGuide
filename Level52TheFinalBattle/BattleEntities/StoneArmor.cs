namespace Level52TheFinalBattle.BattleEntities
{
    public class StoneArmor
    {
        public string Name => "Stone Armor";
        public int ModifyDamage(IBattleEntity source, int damage)
        {
            if (damage <= 0)
            {
                return 0;
            }
            Console.WriteLine($"{source.Name}'s {Name} reduces the damage done by 1.");
            return (damage -= 1);
        }
    }
}
