public interface IBattleEntity
{
    public string Name { get; }
    public List<IBattleCommand> AvailableCommands { get; }
}