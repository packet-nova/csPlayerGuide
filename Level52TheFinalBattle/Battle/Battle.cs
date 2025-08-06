public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private BattleParty _activeParty;

    public IReadOnlyList<IBattleEntity> AllBattleEntities => [.. MonsterEntities, .. HeroEntities];
    public IReadOnlyList<IBattleEntity> HeroEntities => _heroParty.Entities;
    public IReadOnlyList<IBattleEntity> MonsterEntities => _monsterParty.Entities;

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
        var skeleton = new Skeleton();
        var heroParty = new BattleParty([trueProgrammer], heroPlayer);
        var monsterParty = new BattleParty([skeleton], monsterPlayer);

        return new Battle(heroParty, monsterParty);
    }

    /// <summary>
    /// Executes a single turn in the battle, allowing each entity in the active party to perform an action.
    /// </summary>
    public void ExecuteTurn()
    {
        var enemyParty = _activeParty == _heroParty ? _monsterParty : _heroParty;

        foreach (var entity in _activeParty.Entities)
        {
            PrintTurnNotification(entity);
            Console.WriteLine();

            if (_activeParty == _heroParty)
            {
                GetHumanPlayerAction(entity);
            }
        }

        _activeParty = enemyParty;
    }

    /// <summary>
    /// Prompts the human player to select an action for the specified battle entity.
    /// </summary>
    public void GetHumanPlayerAction(IBattleEntity source)
    {
        var actionType = SelectActionCategory(source);

        switch (actionType)
        {
            case ActionType.Attack:
                var attackChoice = SelectAttack(source);
                if (attackChoice.RequiresTarget)
                {
                    var target = SelectTarget();
                    Console.WriteLine($"{source.Name}'s {attackChoice.DisplayName} does {attackChoice.BaseDamage} damage to {target.Name}.");
                }
                else
                {
                    Console.WriteLine($"{source.Name} uses {attackChoice.DisplayName}.");
                }
                attackChoice.Execute();
                break;
            case ActionType.Nothing:
                Console.WriteLine($"{source.Name} does nothing.");
                break;
        }
    }

    /// <summary>
    /// Displays the list of available actions for the specified battle entity and prompts the user to choose one.
    /// </summary>
    public ActionType SelectActionCategory(IBattleEntity entity)
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
    public IBattleEntity SelectTarget()
    {
        Console.WriteLine("Choose a target: ");
        for (int i = 0; i < AllBattleEntities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {AllBattleEntities[i].Name}");
        }

        Console.Write("> ");
        int entityChoice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        return AllBattleEntities[entityChoice - 1];

    }

    /// <summary>
    /// Displays a notification indicating whose turn it is in the battle.
    /// </summary>
    public void PrintTurnNotification(IBattleEntity entity)
    {
        Console.WriteLine($"It is {entity.Name}'s turn.");
    }
}