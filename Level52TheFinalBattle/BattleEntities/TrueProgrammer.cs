public class TrueProgrammer : Character
{
    public override string Name { get; }
    public override int MaxHP { get; } = 25;
    public TrueProgrammer(string name)
    {
        Name = name;
        BattleCommands = [new Punch()];
    }
}
