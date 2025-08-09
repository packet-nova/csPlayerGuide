using System.Runtime.CompilerServices;

public class TheCodedOne : Character
{
    public override string Name { get; } = "The Coded One";
    public override int MaxHP { get; } = 30;

    public TheCodedOne() : base()
    {
        BattleCommands = [new UnravelingAttack()];
    }
}