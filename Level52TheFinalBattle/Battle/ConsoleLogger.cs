using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Battle
{
    public class ConsoleLogger : IBattleLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void TurnNotification(IBattleEntity entity)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"It is {entity.Name}'s turn.");
            Console.ForegroundColor = previousColor;
        }

        public void LogKill(IBattleEntity entity)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{entity.Name} has been defeated!");
            Console.WriteLine();
            Console.ForegroundColor = previousColor;
        }

        public void PlayerWinBattle()
        {
            Console.WriteLine("You won the battle!");
        }
        public void PlayerLoseBattle()
        {
            Console.WriteLine("You lost the battle!");
        }

        public void StatusBanner(Battle battle)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=================================================================================");
            Console.WriteLine("HEROES:");
            PrintEntities(battle.HeroEntities);
            Console.WriteLine();
            Console.WriteLine($"---------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("MONSTERS:");
            PrintEntities(battle.MonsterEntities);
            Console.WriteLine($"=================================================================================");
            Console.ForegroundColor = prevColor;

            void PrintEntities(IReadOnlyList<IBattleEntity> entityList)
            {
                foreach (IBattleEntity entity in entityList)
                {
                    Console.WriteLine($"{entity.Name} HP: {entity.CurrentHP}/{entity.MaxHP}");
                }
            }
        }
    }
}