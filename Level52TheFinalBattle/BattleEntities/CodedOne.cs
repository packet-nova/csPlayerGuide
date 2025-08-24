namespace Level52TheFinalBattle.BattleEntities
{
    public class TheCodedOne : Monster
    {
        public override string Name { get; } = "The Coded One";
        public override int MaxHP { get; } = 30;
        public override int Challenge => 3;

        public TheCodedOne()
        {
            BattleCommands = [new UnravelingAttack()];
        }
    }
}