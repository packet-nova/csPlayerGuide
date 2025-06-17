public class CombatMenu
{
    private readonly Dictionary<CombatAction, string> _displayActions = new()
    {
        [CombatAction.DoNothing]    = "Do Nothing",
        [CombatAction.Attack]       = "Attack",
    };


    public List<CombatAction> Actions { get; } = Enum.GetValues<CombatAction>().ToList();

    public void DisplayMenu()
    {
        for (int i = 0; i < Actions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_displayActions[Actions[i]]}");
        }
        Console.Write($"Choose an action [1-{Actions.Count}]: ");
    }
}
public enum CombatAction { DoNothing, Attack }