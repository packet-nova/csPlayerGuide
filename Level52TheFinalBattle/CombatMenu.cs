public class CombatMenu
{
    public List<CombatActions> Actions { get; private set; } = new List<CombatActions>();
    private readonly Dictionary<CombatActions, string> _displayActions = new Dictionary<CombatActions, string>()
    {
        {CombatActions.DoNothing,   "Do Nothing"},
        {CombatActions.Attack,      "Attack" }
    };


    public CombatMenu()
    {
        Actions.AddRange(Enum.GetValues<CombatActions>());
    }

    public void DisplayMenu()
    {
        for (int i = 0; i < Actions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_displayActions[Actions[i]]}");
        }
        Console.Write($"Choose an action [1-{Actions.Count}]: ");
        //Console.ReadLine();
    }
}
public enum CombatActions { DoNothing, Attack }