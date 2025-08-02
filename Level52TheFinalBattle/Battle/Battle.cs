public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private BattleParty _activeParty;

    public Battle(BattleParty heroParty, BattleParty monsterParty)
    {
        _heroParty = heroParty;
        _monsterParty = monsterParty;
        _activeParty = heroParty;
    }

    /// <summary>
    /// Creates a basic battle scenario between a hero and a skeleton monster.
    /// </summary>
    public static Battle CreateBasicSkeletonBattle(
        TrueProgrammer trueProgrammer, 
        Player heroPlayer, 
        Player monsterPlayer)
    {
        Skeleton skeleton = new();

        var heroParty = new BattleParty([trueProgrammer], heroPlayer);
        var monsterParty = new BattleParty([skeleton], monsterPlayer);

        return new Battle(heroParty, monsterParty);
    }

    /// <summary>
    /// Executes a single turn in the battle, allowing each entity in the active party to perform an action. Then the active party changes sides.
    /// </summary>
    public void ExecuteTurn()
    {
        var enemyParty = _activeParty == _heroParty ? _monsterParty : _heroParty;

        foreach (var entity in _activeParty.Entities)
        {
            PrintTurnNotification(entity);

            if (_activeParty == _heroParty)
            {
                PrintAvailableActions(entity);
            }

            var selectedAction = _activeParty.Controller.InputActionChoice(entity, this);
            Console.WriteLine();

            if (selectedAction.RequiresTarget)
            {
                IBattleEntity target = SelectTarget();
                Console.WriteLine($"{entity.Name}'s {selectedAction} deals 1 damage to {target.Name}.");
            }

            Console.WriteLine();
        }

        _activeParty = enemyParty;
    }

    /// <summary>
    /// Retrieves a read-only list of all battle entities, including both monsters and heroes.
    /// </summary>
    public IReadOnlyList<IBattleEntity> GetAllBattleEntities() => [.. GetMonsterEntities(), .. GetHeroEntities()];

    public IReadOnlyList<IBattleEntity> GetHeroEntities() => _heroParty.Entities;

    public IReadOnlyList<IBattleEntity> GetMonsterEntities() => _monsterParty.Entities;


    public IBattleEntity SelectTarget()
    {
        var validTargets = GetAllBattleEntities();

        Console.WriteLine("Choose a target: ");
        for (int i = 0; i < validTargets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {validTargets[i].Name}");
        }

        Console.Write("Target: ");
        int entityChoice = Convert.ToInt32(Console.ReadLine());

        return validTargets[entityChoice - 1];

    }

    /// <summary>
    /// Displays the list of available actions for the specified battle entity and prompts the user to choose one.
    /// </summary>
    public void PrintAvailableActions(IBattleEntity entity)
    {
        for (int i = 0; i < entity.BattleCommands.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {entity.BattleCommands[i].DisplayName}");
        }
        Console.Write($"Choose an action [1-{entity.BattleCommands.Count}]: ");
    }

    /// <summary>
    /// Displays a notification indicating whose turn it is in the battle.
    /// </summary>
    public void PrintTurnNotification(IBattleEntity entity)
    {
        Console.WriteLine($"It is {entity.Name}'s turn.");
    }
}