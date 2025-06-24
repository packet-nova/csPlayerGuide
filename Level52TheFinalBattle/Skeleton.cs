public class Skeleton : IBattleEntity
{
    public string Name { get; } = "SKELETON";
    public List<IBattleCommand> AvailableCommands { get; private set; } = new List<IBattleCommand>();

    public List<IBattleCommand> GetAvailableCommands(Battle context)
    {
        List<IBattleCommand> options = new();
        options.Add(new DoNothing());
        foreach(var attackTarget in context.GetHeroEntities().Concat(context.GetMonsterEntities()))
            options.Add(new Attack(attackTarget));
        return options;
    }

    public Skeleton()
    {
        AvailableCommands.Add(new DoNothing());
    }
}
