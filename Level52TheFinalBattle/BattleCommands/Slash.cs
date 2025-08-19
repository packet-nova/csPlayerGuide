using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class Slash : IBattleCommand
    {
        public ActionType Category => ActionType.Attack;

        public string DisplayName => "Slash";

        public bool RequiresTarget => true;

        public int BaseDamage => 2;

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            Console.WriteLine($"{source.Name}'s {DisplayName} deals {BaseDamage} damage to {target.Name}.");
            target.TakeDamage(BaseDamage);
        }
    }
}
