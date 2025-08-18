using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Item
{
    internal class LesserHealingPotion : HealingPotion
    {
        public override int HealingAmount => 10;

        public override string Name => "Lesser Healing Potion";
        public override void Execute(IBattleEntity target)
        {
            Console.WriteLine($"{target.Name} is healed by {Name} for {HealingAmount}.");
            target.Heal(HealingAmount);
        }

    }
}
