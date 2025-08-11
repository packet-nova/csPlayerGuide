using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class Punch : IBattleCommand
    {
        public ActionType Category { get; } = ActionType.Attack;
        public string DisplayName => "Punch";
        public int BaseDamage { get; } = 1;
        public bool RequiresTarget { get; } = true;

        public void Execute(IBattleEntity source, IBattleEntity target)
        {
            Console.WriteLine($"{source.Name}'s {DisplayName} deals {BaseDamage} damage to {target.Name}.");
            target.TakeDamage(BaseDamage);
        }
    }
}