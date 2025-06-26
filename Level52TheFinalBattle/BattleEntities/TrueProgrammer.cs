public class TrueProgrammer : IBattleEntity
{
    public string Name { get; private set; }

    public TrueProgrammer(string name)
    {
        Name = name;
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
