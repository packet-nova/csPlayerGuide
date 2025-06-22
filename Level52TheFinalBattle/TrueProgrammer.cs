public class TrueProgrammer : IBattleEntity
{
    public string Name { get; private set; }
    public List<IBattleCommand> AvailableCommands { get; private set; } = new List<IBattleCommand>();
    
    public TrueProgrammer(string name)
    {
        Name = name;
        AvailableCommands.Add(new DoNothing());
        AvailableCommands.Add(new Attack());
    }
}
