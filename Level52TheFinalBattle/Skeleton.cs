public class Skeleton : IBattleEntity
{
    public string Name { get; } = "SKELETON";

    public List<IBattleEntity> GetAvailableTargets(Battle battle)
    {
        List<IBattleEntity> validTargets = new();

        foreach (var target in battle.GetMonsterEntities())
            validTargets.Add(target);

        foreach (var target in battle.GetHeroEntities())
            validTargets.Add(target);

        return validTargets;
    }

    public List<IBattleCommand> GetAvailableCommands(Battle battle)
    {
        List<IBattleCommand> options = new();

        options.Add(new DoNothing());

        foreach (var hostileTarget in battle.GetMonsterEntities())
            options.Add(new Attack(hostileTarget));

        foreach (var friendlyTarget in battle.GetHeroEntities())
            options.Add(new Attack(friendlyTarget));

        return options;
    }

}
