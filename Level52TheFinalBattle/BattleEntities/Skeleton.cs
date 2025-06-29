public class Skeleton : IBattleEntity
{
    public string Name { get; } = "SKELETON";

    public List<IBattleCommand> GetAvailableCommands(Battle battle)
    {
        List<IBattleCommand> commands = new();

        commands.Add(new DoNothing());

        foreach (var hostileTarget in battle.GetHeroEntities())
            commands.Add(new Attack(hostileTarget));

        foreach (var friendlyTarget in battle.GetMonsterEntities())
            commands.Add(new Attack(friendlyTarget));

        return commands;
    }
}
