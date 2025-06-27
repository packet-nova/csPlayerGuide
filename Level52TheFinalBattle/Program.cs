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

    ControlledBy = ControlledBy.Computer,

    Actions = new List<BattleAction>
    {
         nothingAction,

        new BattleAction
        {
            Name = "Punch",
            Type = BattleActionType.Attack
        }
    }
};

var skeleton = new GameEntity
{
    Name = "SKELETON",

    ControlledBy = ControlledBy.Computer,

    Actions = new List<BattleAction>
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
    HeroParty = new List<IGameEntity> {
        trueProgrammer
    },

    EnemyParty = new List<IGameEntity>
    {
        skeleton
    },

    CombatLogEntry = new List<CombatLogEntry>()
};

while (true)
{
    foreach (var hero in battle.HeroParty)
    {
        if (hero.ControlledBy == ControlledBy.Computer)
        {
            var action = hero.Actions.FirstOrDefault(action => action.Type == BattleActionType.Nothing);

            battle.CombatLogEntry.Add(new CombatLogEntry
            {
                SourceEntity = hero,
                TargetEntity = null,
                ActionPerformed = action
            });
        }
        // show a menu with the actions the hero can perform
    }

    foreach (var monster in battle.EnemyParty)
    {
        if (monster.ControlledBy == ControlledBy.Computer)
        {
            var action = monster.Actions.FirstOrDefault(action => action.Type == BattleActionType.Nothing);
        }
        // show a menu with the actions the hero can perform
    }
}

