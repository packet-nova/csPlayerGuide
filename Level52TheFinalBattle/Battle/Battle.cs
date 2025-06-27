public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private readonly BattleUI _battleUI;
    private CurrentTurn _currentTurn;

    public Battle(BattleData data)
    {
        _heroParty = data.HeroParty;
        _monsterParty = data.MonsterParty;
        _currentTurn = data.FirstTurn;
        _battleUI = new(this);
    }
    public void ExecuteTurn()
    {
        BattleParty activeParty = _currentTurn == CurrentTurn.Hero ? _heroParty : _monsterParty;
        
        foreach (var entity in activeParty.Entities)
        {
            if (activeParty == _heroParty)
            {
                _battleUI.PrintTurnNotification(entity);
                _battleUI.PrintAvailableActions(entity);
            }

            var selectedAction = activeParty.Controller.InputActionChoice(entity, this);
            selectedAction.Execute(entity);
        }

        _currentTurn = _currentTurn == CurrentTurn.Hero ? CurrentTurn.Monster : CurrentTurn.Hero;
    }
    public IReadOnlyList<IBattleEntity> GetAllEntities()
    {
        List<IBattleEntity> entities = new();

        entities.AddRange(GetMonsterEntities());
        entities.AddRange(GetHeroEntities());

        return entities;
    }
    public IReadOnlyList<IBattleEntity> GetHeroEntities() => _heroParty.Entities;
    public IReadOnlyList<IBattleEntity> GetMonsterEntities() => _monsterParty.Entities;
}