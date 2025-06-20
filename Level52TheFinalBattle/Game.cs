public class Game
{
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    private TrueProgrammer _trueProgrammer;
    private Battle _currentBattle;

    public Game(Player heroPlayer, Player monsterPlayer)
    {
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
        _trueProgrammer = new(CreateTrueProgrammer());
        StartBattle();
    }

    public void Run()
    {
        while (true)
        {
            _currentBattle.ExecuteTurn();
        }
    }

    public void StartBattle()
    {
        _currentBattle = new(BattleGenerator.CreateBasicSkeletonBattle(_trueProgrammer));
    }

    public string CreateTrueProgrammer()
    {
        Console.Write("What is the True Programmer's name? ");
        return Console.ReadLine();
    }
}
