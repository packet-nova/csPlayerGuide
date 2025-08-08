public class Game
{
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    private readonly TrueProgrammer _trueProgrammer;
    private Battle _currentBattle;

    public Game(TrueProgrammer trueProgrammer, Player heroPlayer, Player monsterPlayer)
    {
        _trueProgrammer = trueProgrammer;
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
    }

    public void Run()
    {
        StartBattle();

        while (_currentBattle.IsActive)
        {
            _currentBattle.ExecuteTurn();
        }
    }

    public void StartBattle()
    {
        _currentBattle = Battle.CreateBasicSkeletonBattle(
            _trueProgrammer,
            _heroPlayer,
            _monsterPlayer);
    }
}
