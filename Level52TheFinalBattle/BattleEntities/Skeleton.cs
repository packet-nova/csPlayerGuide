public class Skeleton : Character
{
    public override string Name { get; } = "Skeleton";
    public override int MaxHP { get; } = 5;

    public Skeleton() : base()
    {
        BattleCommands = [new BoneCrunch()];
    }
}
