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
                1 => CreateEasyMonsters(),
                2 => [.. CreateEasyMonsters(), .. CreateEasyMonsters()],
                3 => [new TheUncodedOne()],
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {battleTier}.")
            };

            var monsterParty = new BattleParty(monsters, monsterController);

            return new BattleData()
            {
                HeroParty = heroParty,
                MonsterParty = monsterParty,
            };
        }

        public List<IBattleEntity> CreateEasyMonsters()
        {
            List<IBattleEntity> monsters = [];
            int count = rng.Next(1, 3);
            Console.WriteLine($"DEBUG: Creating {count} monster(s)");

            for (int i = 0; i < count; i++)
            {
                int m = rng.Next(1, 3);

                if (m % 2 == 0)
                {
                    monsters.Add(new Skeleton());
                    Console.WriteLine($"DEBUG: Added Skeleton");
                }

                else
                {
                    monsters.Add(new StoneAmarok());
                    Console.WriteLine($"DEBUG: Added Stone Amarok");
                }
            }
            Console.WriteLine("DEBUG: Press any key to continue...");
            Console.ReadKey();

            return monsters;
        }
    }
}
