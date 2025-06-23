public class BattleUI
{
    public void PrintAvailableActions(IBattleEntity entity)
    {
        for(int i = 0; i < entity.AvailableCommands.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {entity.AvailableCommands[i].GetDisplayName(entity)}");
        }
        Console.Write($"Choose an action [1-{entity.AvailableCommands.Count}]: ");
    }

    public void PrintTurnNotification(IBattleEntity entity)
    {
        Console.WriteLine();
        Console.WriteLine($"It is {entity.Name}'s turn.");
    }
}