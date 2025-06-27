//HumanPlayer p1 = new();
//ComputerPlayer p2 = new();
//TrueProgrammer trueProgrammer = new(CreateTrueProgrammer());

//Game game = new(trueProgrammer, p1, p2);

//game.Run();

//string CreateTrueProgrammer()
//{
//    Console.Write("What is the True Programmer's name? ");
//    return Console.ReadLine();
//}




var nothingAction = new BattleAction
{
    Name = "Nothing",

    Type = BattleActionType.Nothing
};

var trueProgrammer = new GameEntity
{
    Name = "Nate",

    ControlledBy = ControlledBy.Human,

    Actions = new List<IBattleAction>
    {
         nothingAction,

        new BattleAction
        {
            Name = "PUNCH",
            Type = BattleActionType.Attack
        }
    }
};

var skeleton = new GameEntity
{
    Name = "SKELETON",

    ControlledBy = ControlledBy.Computer,

    Actions = new List<IBattleAction>
    {

        new BattleAction
        {
            Name = "BONE CRUNCH",
            Type = BattleActionType.Attack
        },

        nothingAction,

    }
};

var battle = new GameBattle
{
    HeroParty = new List<IGameEntity>
    {
        trueProgrammer
    },

    MonsterParty = new List<IGameEntity>
    {
        skeleton
    },

    CombatLogEntry = new List<CombatLogEntry>()
};

while (true)
{
    // Hero Party's Turn
    foreach (var hero in battle.HeroParty)
    {
        Console.WriteLine($"It is {hero.Name}'s turn.");

        // Action menu display/select
        switch (hero.ControlledBy)
        {
            case ControlledBy.Human:

                // Display available actions
                for (int index = 0; index < hero.Actions.Count; index++)
                {
                    Console.WriteLine($"{index + 1}. {hero.Actions[index]}");
                }

                Console.Write($"What Action? (1-{hero.Actions.Count}): ");

                // Get user action choice
                var isValidActionChoice = int.TryParse(Console.ReadLine(), out int actionChoice) &&
                    (actionChoice is > 0 && actionChoice <= hero.Actions.Count);

                while (isValidActionChoice == false)
                {
                    Console.WriteLine("Invalid entry.");
                    Console.Write($"What Action? (1-{hero.Actions.Count}): ");

                    isValidActionChoice = int.TryParse(Console.ReadLine(), out actionChoice) &&
                        (actionChoice is > 0 && actionChoice <= hero.Actions.Count);
                }

                // Assigning action choice
                var selectedAction = hero.Actions[actionChoice - 1];
                Thread.Sleep(500);


                // Display available targets
                for (int index = 0; index < battle.MonsterParty.Count; index++)
                {
                    Console.WriteLine($"{index + 1}. {battle.MonsterParty[index]}");
                }

                // Get user target choice
                Console.Write($"What target? (1-{battle.MonsterParty.Count}): ");

                var isValidTargetChoice = int.TryParse(Console.ReadLine(), out int targetChoice) &&
                    (targetChoice is > 0 && targetChoice <= battle.MonsterParty.Count);

                while (isValidTargetChoice == false)
                {
                    Console.WriteLine("Invalid entry.");
                    Console.Write($"What target? (1-{battle.MonsterParty.Count}): ");

                    isValidTargetChoice = int.TryParse(Console.ReadLine(), out targetChoice) &&
                        (targetChoice is > 0 && targetChoice <= battle.MonsterParty.Count);
                }

                // Assigning target choice
                var selectedTarget = battle.MonsterParty[targetChoice - 1];

                // Log entry
                var heroLogEntry = new CombatLogEntry()
                {
                    SourceEntity = hero,
                    TargetEntity = selectedTarget,
                    ActionPerformed = selectedAction
                };

                battle.CombatLogEntry.Add(heroLogEntry);

                Console.WriteLine(heroLogEntry);
                Console.WriteLine();
                break;

            case ControlledBy.Computer:

                var target = battle.HeroParty.First();

                //var action = hero.Actions.First(action => action.Type == BattleActionType.Nothing);
                var action = hero.Actions.First(action => action.Type == BattleActionType.Attack);
                Thread.Sleep(500);

                var logEntry = new CombatLogEntry()
                {
                    SourceEntity = hero,
                    TargetEntity = target,
                    ActionPerformed = action
                };

                battle.CombatLogEntry.Add(logEntry);

                Console.WriteLine(logEntry);
                Console.WriteLine();
                break;
        }
    }

    // Monster Party's Turn
    foreach (var monster in battle.MonsterParty)
    {
        Console.WriteLine($"It is {monster.Name}'s turn.");

        var target = battle.HeroParty.First();

        //var action = hero.Actions.First(action => action.Type == BattleActionType.Nothing);
        var action = monster.Actions.First(action => action.Type == BattleActionType.Attack);
        Thread.Sleep(500);

        var logEntry = new CombatLogEntry()
        {
            SourceEntity = monster,
            TargetEntity = target,
            ActionPerformed = action
        };

        battle.CombatLogEntry.Add(logEntry);

        Console.WriteLine(logEntry);
        Console.WriteLine();
        break;
    }
}

