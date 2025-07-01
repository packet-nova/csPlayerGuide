public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private CurrentTurn _currentTurn;

    public Battle(BattleData data)
    {
        _heroParty = data.HeroParty;
        _monsterParty = data.MonsterParty;
        _currentTurn = data.FirstTurn;
    }

    /// <summary>
    /// Executes a single turn in the battle, allowing each entity in the active party to perform an action. The the active party changes sides.
    /// </summary>
    public void ExecuteTurn()
    {
        BattleParty activeParty = _currentTurn == CurrentTurn.Hero ? _heroParty : _monsterParty;

        foreach (var entity in activeParty.Entities)
        {
            if (activeParty == _heroParty)
            {
                PrintTurnNotification(entity);
                PrintAvailableActions(entity);
            }

            var selectedAction = activeParty.Controller.InputActionChoice(entity, this);
            selectedAction.Execute(entity);
        }

        _currentTurn = _currentTurn == CurrentTurn.Hero ? CurrentTurn.Monster : CurrentTurn.Hero;
    }

    /// <summary>
    /// Retrieves all battle entities, including both monsters and heroes.
    /// </summary>
    /// <returns>A read-only list of all battle entities. The list includes both monster entities and hero entities.</returns>
    public IReadOnlyList<IBattleEntity> GetAllBattleEntities() => [.. GetMonsterEntities(), .. GetHeroEntities()];

    public IReadOnlyList<IBattleEntity> GetHeroEntities() => _heroParty.Entities;

    public IReadOnlyList<IBattleEntity> GetMonsterEntities() => _monsterParty.Entities;


    /// <summary>
    /// Displays the list of available actions for the specified battle entity and prompts the user to choose one.
    /// </summary>
    public void PrintAvailableActions(IBattleEntity entity)
    {
        for (int i = 0; i < entity.GetAvailableCommands(this).Count; i++)
        {
            Console.WriteLine($"{i + 1}. {entity.GetAvailableCommands(this)[i].GetDisplayName(entity)}");
        }
        Console.Write($"Choose an action [1-{entity.GetAvailableCommands(this).Count}]: ");
    }

    /// <summary>
    /// Displays a notification indicating whose turn it is in the battle.
    /// </summary>
    public void PrintTurnNotification(IBattleEntity entity)
    {
        Console.WriteLine();
        Console.WriteLine($"It is {entity.Name}'s turn.");
    }
}