using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;

public class InputHandler
{
    /// <summary>
    /// Displays the list of available actions for the specified battle entity and prompts the user to choose one.
    /// </summary>
    public ActionType SelectActionCategory()
    {
        var actionTypes = Enum.GetValues<ActionType>();

        Console.WriteLine("What do you want to do?");

        for (int i = 0; i < Enum.GetNames<ActionType>().Length; i++)
        {
            Console.WriteLine($"{i + 1}. {actionTypes[i]}");
        }

        Console.Write(">  ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        return actionTypes[choice - 1];
    }

    /// <summary>
    /// Displays a list of attack actions available to the specified battle entity and prompts the user to select one.
    /// </summary>
    public IBattleCommand SelectAttack(IBattleEntity entity)
    {
        var attackActions = entity.BattleCommands
            .Where(action => action.Category == ActionType.Attack);

        int index = 1;
        Console.WriteLine("Which attack?");

        foreach (var action in attackActions)
        {
            Console.WriteLine($"{index++}. {action.DisplayName}");
        }

        Console.Write(">  ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        return attackActions.ElementAt(choice - 1);
    }

    /// <summary>
    /// Prompts the user to select a target from a list of available battle entities.
    /// </summary>
    public IBattleEntity SelectTarget(IReadOnlyList<IBattleEntity> allEntities)
    {
        Console.WriteLine("Choose a target: ");
        for (int i = 0; i < allEntities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allEntities[i].Name} ({allEntities[i].CurrentHP}/{allEntities[i].MaxHP} HP)");
        }

        Console.Write("> ");
        int entityChoice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        return allEntities[entityChoice - 1];
    }

    public int GetValidInput(string prompt, int minValue, int maxValue)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= minValue && number <= maxValue)
            {
                return number;
            }

            Console.WriteLine($"Input must be a number must be between {minValue} and {maxValue}.");
        }
    }
}
