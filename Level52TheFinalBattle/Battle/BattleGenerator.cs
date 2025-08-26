using Level52TheFinalBattle.BattleEntities;


namespace Level52TheFinalBattle.Battle
{
    public class BattleGenerator
    {
        private Random rng = new();
        public BattleData GenerateBattle(
            BattleParty heroParty,
            Player heroController,
            Player monsterController,
            int battleTier)
        {
            List<IBattleEntity> monsters = battleTier switch
            {
                1 => CreateEasyBattle(),
                //2 => [new Skeleton(), new Zombie()],
                //3 => [new TheCodedOne()],
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {battleTier}.")
            };

            var monsterParty = new BattleParty(monsters, monsterController);

            return new BattleData()
            {
                HeroParty = heroParty,
                MonsterParty = monsterParty,
            };
        }

        public List<IBattleEntity> CreateEasyBattle()
        {
            List<IBattleEntity> monsters = [];
            int count = rng.Next(1, 3);
            for (int i = 0; i < count; i++)
            {
                int m = rng.Next(1, 3);

                if (m % 2 == 0)
                {
                    monsters.Add(new Skeleton());
                }

                else
                {
                    monsters.Add(new Zombie());
                }
            }

            return monsters;
        }
    }
}
