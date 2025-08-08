public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private BattleParty _activeParty;
    private IBattleLogger _consoleLogger;

    public IReadOnlyList<IBattleEntity> AllBattleEntities => [.. MonsterEntities, .. HeroEntities];
    public IReadOnlyList<IBattleEntity> HeroEntities => _heroParty.Entities;
    public IReadOnlyList<IBattleEntity> MonsterEntities => _monsterParty.Entities;
    public bool IsActive => !_heroParty.IsEmpty && !_monsterParty.IsEmpty;

    public Battle(BattleParty heroParty, BattleParty monsterParty, IBattleLogger logger)
    {
        _heroParty = heroParty;
        _monsterParty = monsterParty;
        _activeParty = heroParty;
        _consoleLogger = logger;
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
        var consoleLogger = new ConsoleLogger();

        return new Battle(heroParty, monsterParty, consoleLogger);
    }

    /// <summary>
    /// Executes a single turn in the battle, allowing each entity in the active party to perform an action.
    /// </summary>
    public void ExecuteTurn()
    {
        // The enemy party is relative to the current active party.
        // If the current active party is _heroParty, the enemy party is _monsterParty and vice-versa.
        var enemyParty = _activeParty == _heroParty ? _monsterParty : _heroParty;

        foreach (var entity in _activeParty.Entities)
        {
            _consoleLogger.TurnNotification(entity);

            if (_activeParty == _heroParty)
            {
                GetHumanPlayerAction(entity);
            }
            else
            {
                GetComputerPlayerAction(entity);
            }
        }

        HandleDead();

        if (_monsterParty.IsEmpty)
        {
            _consoleLogger.PlayerWin();
        }
        else
        {
            _consoleLogger.PlayerLose();
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
                    attackChoice.Execute(source, target);
                }
                else
                {
                    Console.WriteLine($"{source.Name} uses {attackChoice.DisplayName}.");
                }
                break;
            case ActionType.Nothing:
                Console.WriteLine($"{source.Name} does nothing.");
                break;
        }
    }

    /// <summary>
    /// Determines and executes the action for a computer-controlled player during a battle.
    /// </summary>
    public void GetComputerPlayerAction(IBattleEntity source)
    {
        Random rng = new();
        if (source is Skeleton)
        {
            var targetIndex = rng.Next(HeroEntities.Count);
            var target = HeroEntities[targetIndex];
            IBattleCommand attackChoice = source.BattleCommands[0];
            attackChoice.Execute(source, target);
        }
        else
        {
            Console.WriteLine($"{source.Name} does nothing.");
        }
    }

    public BattleParty GetPartyFor(IBattleEntity entity) => HeroEntities.Contains(entity) ? _heroParty : _monsterParty;
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

    public void HandleDead()
    {
        foreach (var entity in AllBattleEntities)
        {
            if (entity.IsDead)
            {
                _consoleLogger.LogKill(entity);
                GetPartyFor(entity).Entities.Remove(entity);
            }
        }
    }


}