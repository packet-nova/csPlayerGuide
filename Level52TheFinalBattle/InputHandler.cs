using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.Item;

public class InputHandler
{
    public ActionType SelectActionCategory()
    {
        var actionTypes = Enum.GetValues<ActionType>();

        Console.WriteLine("What do you want to do?");
        for (int i = 0; i < Enum.GetNames<ActionType>().Length; i++)
        {
            Console.WriteLine($"{i + 1}. {actionTypes[i]}");
        }

        int choice = GetValidInput("> ", 1, actionTypes.Length);
        Console.WriteLine($"You chose: {actionTypes[choice - 1]}");
        Console.WriteLine();
        
        return actionTypes[choice - 1];
    }

    public IBattleCommand SelectAttack(IBattleEntity entity)
    {
        var attackActions = entity.BattleCommands
            .Where(action => action.Category == ActionType.Attack)
            .ToList();

        Console.WriteLine("Which attack?");

        for (int i = 0; i < attackActions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {attackActions[i].DisplayName}");
        }

        int choice = GetValidInput("> ", 1, attackActions.Count);
        Console.WriteLine($"You chose: {attackActions.ElementAt(choice - 1).DisplayName}");
        Console.WriteLine();

        return attackActions.ElementAt(choice - 1);
    }

    public InventoryItem SelectItem(BattleParty party)
    {
        var consumables = party.Items.OfType<IConsumable>().Cast<InventoryItem>();
        int i = 1;

        foreach (var item in consumables)
        {
            Console.WriteLine($"{i}. {item.Name}");
            i++;
        }
        
        int choice = GetValidInput("> ", 1, i - 1);
        Console.WriteLine($"You chose: {consumables.ElementAt(choice - 1).Name}");
        Console.WriteLine();
        
        return consumables.ElementAt(choice - 1);
    }

    public IBattleEntity SelectTarget(IReadOnlyList<IBattleEntity> allEntities)
    {
        Console.WriteLine("Choose a target: ");
        for (int i = 0; i < allEntities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allEntities[i].Name} ({allEntities[i].CurrentHP}/{allEntities[i].MaxHP} HP)");
        }

        int choice = GetValidInput("> ", 1, allEntities.Count);
        Console.WriteLine($"You chose: {allEntities.ElementAt(choice - 1).Name}");
        Console.WriteLine();

        return allEntities[choice - 1];
    }

    public int GetValidInput(string prompt, int minValue, int maxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= minValue && number <= maxValue)
            {
                return number;
            }

            Console.WriteLine($"Input must be a number between {minValue} and {maxValue}.");
        }
    }
}
