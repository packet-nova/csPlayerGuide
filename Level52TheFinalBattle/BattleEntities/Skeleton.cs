using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class Skeleton : Character
    {
        public override string Name { get; }
        public override int MaxHP { get; } = 1;

        public Skeleton()
        {
            BattleCommands = [new BoneCrunch()];
            Name = RandomName();
        }

        private string RandomName()
        {
            Random random = new();
            List<string> names = [
                "Teddy Bonesevelt",
                "Albert Spinestein",
                "Spooky McBoneface",
                "Napoleon Bonepart"];

            return names[random.Next(names.Count)];
        }
    }
}