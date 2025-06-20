public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private readonly BattleMenu _battleMenu;
    private CurrentTurn _currentTurn;

    public Battle(BattleData data)
    {
        _heroParty = data.HeroParty;
        _monsterParty = data.MonsterParty;
        _currentTurn = data.FirstTurn;
        _battleMenu = new();
    }

    public void ExecuteTurn()
    {
        if (_currentTurn == CurrentTurn.Heroes)
            _heroParty.PlayerController.TakeTurn(_battleMenu, _heroParty);
        else
            _monsterParty.PlayerController.TakeTurn(_battleMenu, _monsterParty);

        _currentTurn = _currentTurn == CurrentTurn.Heroes ? CurrentTurn.Monsters : CurrentTurn.Heroes;
    }
}