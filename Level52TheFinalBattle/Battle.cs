public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private BattleMenu _battleMenu;
    private BattleParty _currentTurn;

    public Battle(BattleParty heroParty, BattleParty monsterParty)
    {
        _heroParty = heroParty;
        _monsterParty = monsterParty;
        _currentTurn = heroParty;
        _battleMenu = new(this);
    }


    public void ExecuteTurn(Player heroPlayer, Player monsterPlayer)
    {
        if (_currentTurn == _heroParty)
            heroPlayer.TakeTurn(_battleMenu, _heroParty);
        else
            monsterPlayer.TakeTurn(_battleMenu, _monsterParty);

        _currentTurn = _currentTurn == _heroParty ? _monsterParty : _heroParty;
    }
}