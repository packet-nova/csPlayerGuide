using Level52TheFinalBattle.BattleCommands;

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
    }
}