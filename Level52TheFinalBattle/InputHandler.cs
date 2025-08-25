using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.Item;

public class InputHandler
{
    private static readonly Dictionary<ActionType, string> ActionTypeDisplayName = new()
    {
        { ActionType.Attack, "Attack" },
        { ActionType.Item, "Use Item" },
        { ActionType.EquipItem, "Equip Item" },
        { ActionType.Nothing, "Do Nothing" }
    };

    public ActionType SelectActionCategory()
    {
        var actionTypes = ActionTypeDisplayName.Keys.ToList();

        Console.WriteLine("What do you want to do?");
        for (int i = 0; i < actionTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ActionTypeDisplayName[actionTypes[i]]}");
        }

        int choice = GetValidInput("> ", 1, actionTypes.Count);
        Console.WriteLine($"You chose: {ActionTypeDisplayName[actionTypes[choice - 1]]}");
        Console.WriteLine();

        return actionTypes[choice - 1];
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

    public T SelectFromList<T>(IEnumerable<T> items, Func<T, string> getDisplayName)
    {
        var list = items.ToList();

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {getDisplayName(list[i])}");
        }

        int choice = GetValidInput("> ", 1, list.Count);
        Console.WriteLine($"You chose: {getDisplayName(list[choice - 1])}");
        Console.WriteLine();

        return list.ElementAt(choice - 1);
    }
}
