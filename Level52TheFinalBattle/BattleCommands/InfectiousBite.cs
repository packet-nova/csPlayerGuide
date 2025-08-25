using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class InfectiousBite : IBattleCommand
    {
        public ActionType Category => ActionType.Attack;

        public string Name => "Infectious Bite";

        public bool RequiresTarget => true;

        public int BaseDamage => 1;

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{source.Name}'s {Name} deals {BaseDamage} damage to {target.Name}.");
            Console.ForegroundColor = prevColor;
            target.TakeDamage(BaseDamage);
        }
    }
}
