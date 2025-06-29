using Level52TheFinalBattle.Battle;
using Level52TheFinalBattle.Entities;

Console.Write("What is the True Programmer's name? ");
var trueProgrammerName = Console.ReadLine();

// set up the player character
var trueProgrammer = new GameEntity
{
    Name = trueProgrammerName,

    ControlledBy = ControlledBy.Human,

    MaxHealth = 25,

    Health = 25,

    Actions =
    [
        BattleAction.Nothing,

        new BattleAction
        {
            Name = "PUNCH",
            Type = BattleActionType.Attack,
        }
    ]
};

// set up the monster
var skeleton = new GameEntity
{
    Name = "SKELETON",

    MaxHealth = 5,

    Health = 5,

    ControlledBy = ControlledBy.Computer,

    Actions =
    [
        BattleAction.Nothing,

        new BattleAction
        {
            Name = "BONE CRUNCH",
            Type = BattleActionType.Attack
        }
    ]
};

// start a new battle
var battle = new GameBattle
{
    HeroParty = [trueProgrammer],

    MonsterParty = [skeleton],

    CombatLogEntry = []
};

// execute the battle loop
while (true)
{
    // Hero party always goes first
    foreach (var hero in battle.HeroParty)
    {
        Console.WriteLine($"It is {hero.Name}'s turn.");

        battle.TakeTurn(hero);
    }

    // Monster party takes their turn after the heroes
    foreach (var monster in battle.MonsterParty)
    {
        Console.WriteLine($"It is {monster.Name}'s turn.");

        battle.TakeTurn(monster);
    }
}


