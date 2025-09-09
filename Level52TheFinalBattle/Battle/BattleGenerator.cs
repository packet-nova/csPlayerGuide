using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.Item;

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
                1 => CreateEasyMonster(rng.Next(1, 3)),
                2 => CreateEasyMonster(rng.Next(2, 4)),
                3 => [new TheUncodedOne()],
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {battleTier}.")
            };

            var monsterParty = new BattleParty(monsters, monsterController);
            monsterParty.Items.Add(new LesserHealingPotion());

            return new BattleData()
            {
                HeroParty = heroParty,
                MonsterParty = monsterParty,
            };
        }

        public List<IBattleEntity> CreateEasyMonster(int quantity)
        {
            List<IBattleEntity> monsters = [];
            Console.WriteLine($"DEBUG: Creating {quantity} monster(s)");

            for (int i = 0; i < quantity; i++)
            {
                int monsterChoice = rng.Next(0, 3);

                switch (monsterChoice)
                {
                    case 0:
                        monsters.Add(new Skeleton());
                        Console.WriteLine($"DEBUG: Added Skeleton");
                        break;
                    case 1:
                        monsters.Add(new StoneAmarok());
                        Console.WriteLine($"DEBUG: Added Stone Amarok");
                        break;
                    case 2:
                        monsters.Add(new Zombie());
                        Console.WriteLine($"DEBUG: Added Zombie");
                        break;
                    default:
                        monsters.Add(new Skeleton());
                        Console.WriteLine($"DEBUG: OUT OF BOUNDS - Default to Skeleton");
                        break;
                }
            }
            Console.WriteLine("DEBUG: Press any key to continue...");
            Console.ReadKey();

            return monsters;
        }
    }
}
