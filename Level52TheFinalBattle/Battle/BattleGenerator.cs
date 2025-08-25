using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Battle
{
    public class BattleGenerator
    {
        private readonly Random rng = new();

        public List<Monster> EasyMonsters { get; private set; } = [new Skeleton()];
        public List<Monster> BossMonsters { get; private set; } = [new TheCodedOne()];

        public BattleData GenerateBattle(
            BattleParty heroParty,
            Player heroController,
            Player monsterController,
            int battleTier)
        {
            List<IBattleEntity> monsters = battleTier switch
            {
                1 => [EasyMonsters[rng.Next(EasyMonsters.Count)]],
                2 => [BossMonsters[rng.Next(BossMonsters.Count)]],
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {battleTier}.")
            };

            var monsterParty = new BattleParty(monsters, monsterController);
            
            return new BattleData()
            {
                HeroParty = heroParty,
                MonsterParty = monsterParty,
            };
        }

        public Monster RandomEasyMonster()
        {
            var monster = EasyMonsters.ElementAt(rng.Next(EasyMonsters.Count));
            return monster;
        }
    }
}
