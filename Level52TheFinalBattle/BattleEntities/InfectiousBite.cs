using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.BattleEntities
{
    public class InfectiousBite : IBattleCommand
    {
        public ActionType Category => ActionType.Attack;

        public string DisplayName => "Infectious Bite";

        public bool RequiresTarget => true;

        public int BaseDamage => 2;

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{source.Name}'s {DisplayName} deals {BaseDamage} damage to {target.Name}.");
            target.TakeDamage(BaseDamage);
            Console.ForegroundColor = prevColor;
        }
    }
}
