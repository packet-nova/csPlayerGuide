public class Skeleton : IBattleEntity
{
    public string Name { get; } = "SKELETON";
    
    public List<IBattleCommand> BattleCommands { get; } =
    [
       new DoNothing(),
       new Attack()
    ];
}
