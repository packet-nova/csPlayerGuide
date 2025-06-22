public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private readonly BattleMenu _battleMenu;
    private readonly TurnHandler _turnHandler;
    private CurrentTurn _currentTurn;

    public Battle(BattleData data)
    {
        _heroParty = data.HeroParty;
        _monsterParty = data.MonsterParty;
        _currentTurn = data.FirstTurn;
        _battleMenu = new();
        _turnHandler = new();
    }

    public void TakeTurn(BattleParty party, TurnHandler handler)
    {
        foreach (var entity in party.Entities)
        {
            handler.ExecuteEntityTurn(entity, handler);
        }
    }

    public void ExecuteTurn()
    {
        Player heroController = _heroParty.Controller;
        Player monsterController = _monsterParty.Controller;

        if (_currentTurn == CurrentTurn.Hero)
        {
            _battleMenu.PrintEntityTurnNotification(GetHeroEntities()[0]);
            heroController.TakeTurn(_heroParty, _turnHandler);
        }
        else
            monsterController.TakeTurn(_monsterParty, _turnHandler);

        _currentTurn = _currentTurn == CurrentTurn.Hero ? CurrentTurn.Monster : CurrentTurn.Hero;
    }

    public IReadOnlyList<IBattleEntity> GetHeroEntities() => _heroParty.Entities;
    public IReadOnlyList<IBattleEntity> GetMonsterEntities() => _monsterParty.Entities;
}