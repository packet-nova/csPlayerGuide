public class Skeleton : IBattleEntity
{
    public string Name { get; } = "Skeleton";
    
    public List<IBattleCommand> BattleCommands { get; } =
    [
       new BoneCrunch()
    ];
}
