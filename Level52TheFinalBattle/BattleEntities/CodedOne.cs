namespace Level52TheFinalBattle.BattleEntities
{
    public class TheCodedOne : Character
    {
        public override string Name { get; } = "The Coded One";
        public override int MaxHP { get; } = 1;

        public TheCodedOne()
        {
            BattleCommands = [new UnravelingAttack()];
        }
    }
}