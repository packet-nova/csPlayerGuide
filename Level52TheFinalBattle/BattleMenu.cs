public class BattleMenu
{
    public List<BattleAction> AvailableActions { get; private set; } = Enum.GetValues<BattleAction>().ToList();

    private readonly Dictionary<BattleAction, string> _displayActions = new()
    {
        [BattleAction.DoNothing]    = "Do Nothing",
        [BattleAction.Attack]       = "Attack",
    };

    public void PrintActionMenu()
    {
        for (int i = 0; i < AvailableActions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_displayActions[AvailableActions[i]]}");
        }
        Console.Write($"Choose an action [1-{AvailableActions.Count}]: ");
    }

    public void PrintEntityTurnNotification(IBattleEntity entity)
    {
        Console.WriteLine();
        Console.WriteLine($"It is {entity.Name}'s turn.");
    }
}