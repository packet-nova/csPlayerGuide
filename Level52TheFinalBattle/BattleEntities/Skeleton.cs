using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.BattleEntities
{
    public class Skeleton : Monster
    {
        public override string Name { get; }
        public override int MaxHP { get; } = 5;
        public override int Challenge => 1;

        public Skeleton()
        {
            BattleCommands = [new BoneCrunch()];
            Name = RandomName();
            SetStartingInventory();
        }

        private string RandomName()
        {
            Random random = new();
            List<string> names = [
                "Teddy Bonesevelt",
                "Albert Spinestein",
                "Spooky McBoneface",
                "Thomas Dedison",
                "Napoleon Bonepart"];

            return names[random.Next(names.Count)];
        }
        private void SetStartingInventory()
        {
            Random rng = new();
            bool potionChance = rng.Next(2) == 0;
            bool daggerChance = rng.Next(2) == 0;

            Items.Add(new Bone());

            if (potionChance)
            {
                Items.Add(new LesserHealingPotion());
            }

            if (daggerChance)
            {
                Items.Add(new Dagger());
            }

            if (!Items.OfType<Dagger>().Any())
            {
                EquippedItems.Add(new Dagger());
            }
        }
    }
}