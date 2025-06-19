public class Game
{
    private readonly List<IBattleEntity> _heroParty = new List<IBattleEntity>();
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    private TrueProgrammer _trueProgrammer;
    private Battle _currentBattle;

    public Game(Player heroPlayer, Player monsterPlayer)
    {
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
        _trueProgrammer = new(CreateTrueProgrammer());
        _heroParty.Add(_trueProgrammer);
        StartBattle();
    }

    public void Run()
    {
        while (true)
        {
            _currentBattle.ExecuteTurn(_heroPlayer, _monsterPlayer);
        }
    }

    public void StartBattle()
    {
        var monsterParty = new List<IBattleEntity> { new Skeleton() };
        BattleMenu menu = new();
        _currentBattle = new(_heroParty, monsterParty, menu);
    }

    public string CreateTrueProgrammer()
    {
        Console.Write("What is the True Programmer's name? ");
        return Console.ReadLine();
    }
}
