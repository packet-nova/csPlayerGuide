public class BattleUI
{
    private Battle _battle;

    public BattleUI(Battle battle)
    {
        _battle = battle;
    }
    public void PrintAvailableActions(IBattleEntity entity)
    {
        for(int i = 0; i < entity.GetAvailableCommands(_battle).Count; i++)
        {
            Console.WriteLine($"{i + 1}. {entity.GetAvailableCommands(_battle)[i].GetDisplayName(entity)}");
        }
        Console.Write($"Choose an action [1-{entity.GetAvailableCommands(_battle).Count}]: ");
    }

    public void PrintTurnNotification(IBattleEntity entity)
    {
        Console.WriteLine();
        Console.WriteLine($"It is {entity.Name}'s turn.");
    }
}