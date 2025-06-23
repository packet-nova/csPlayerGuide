public class Skeleton : IBattleEntity
{
    public string Name { get; } = "SKELETON";
    public List<IBattleCommand> AvailableCommands { get; private set; } = new List<IBattleCommand>();

    public Skeleton()
    {
        AvailableCommands.Add(new DoNothing());
        AvailableCommands.Add(new Attack());
    }
}
