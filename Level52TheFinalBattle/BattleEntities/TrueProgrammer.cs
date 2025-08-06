public class TrueProgrammer : IBattleEntity
{
    public string Name { get; private set; }

    public TrueProgrammer(string name)
    {
        Name = name;
    }

    public List<IBattleCommand> BattleCommands { get; } =
    [
       new Punch()
    ];
}
