using Level52TheFinalBattle.BattleEntities;
using System.Dynamic;

namespace Level52TheFinalBattle.Battle
{
    public class BattleGenerator
    {
        private readonly Random rng = new();

        public BattleData GenerateBattle(
            BattleParty heroParty,
            Player heroController,
            Player monsterController,
            int battleTier)
        {
            List<IBattleEntity> monsters = battleTier switch
            {
                1 => [new Skeleton()],
                2 => [new Skeleton(), new Zombie()],
                3 => [new TheCodedOne()],
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {battleTier}.")
            };

            var monsterParty = new BattleParty(monsters, monsterController);

            return new BattleData()
            {
                HeroParty = heroParty,
                MonsterParty = monsterParty,
            };
        }
    }
}
