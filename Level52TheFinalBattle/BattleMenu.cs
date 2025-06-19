public class BattleMenu
{
    private readonly Dictionary<BattleAction, string> _displayActions = new()
    {
        [BattleAction.DoNothing]    = "Do Nothing",
        [BattleAction.Attack]       = "Attack",
    };

    public List<BattleAction> AvailableActions { get; private set; } = Enum.GetValues<BattleAction>().ToList();

    public void DisplayMenu()
    {
        for (int i = 0; i < AvailableActions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_displayActions[AvailableActions[i]]}");
        }
        Console.Write($"Choose an action [1-{AvailableActions.Count}]: ");
    }
}
public enum BattleAction { DoNothing, Attack }