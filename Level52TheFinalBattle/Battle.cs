public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private BattleMenu _battleMenu;
    private BattleParty _currentTurn;

    public Battle(BattleParty heroParty, BattleParty monsterParty, BattleMenu menu)
    {
        _heroParty = heroParty;
        _monsterParty = monsterParty;
        _battleMenu = menu;
        _currentTurn = heroParty;
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