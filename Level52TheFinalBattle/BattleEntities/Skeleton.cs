public class Skeleton : IBattleEntity
{
    public string Name { get; } = "SKELETON";


    public List<IBattleCommand> GetAvailableCommands(Battle battle)
    {
        List<IBattleCommand> commands = [new DoNothing()];
        return commands;
    }
}
