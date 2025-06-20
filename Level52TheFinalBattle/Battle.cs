public class Battle
{
    private readonly BattleParty _heroParty;
    private readonly BattleParty _monsterParty;
    private readonly BattleMenu _battleMenu;
    private readonly TurnHandler _turnHandler;
    private CurrentTurn _currentTurn;

    /// <summary>
    /// Initializes a new instance of the <see cref="Battle"/> class with the specified battle data.
    /// </summary>
    /// <remarks>The <paramref name="data"/> parameter must contain valid hero and monster party information,
    /// as well as a defined starting turn.  This constructor sets up the battle state and prepares the turn handler and
    /// battle menu for use.</remarks>
    /// <param name="data">The data used to initialize the battle, including hero and monster parties, the starting turn, and other
    /// configuration details.</param>
    public Battle(BattleData data)
    {
        _heroParty = data.HeroParty;
        _monsterParty = data.MonsterParty;
        _currentTurn = data.FirstTurn;
        _battleMenu = new();
        _turnHandler = new(_battleMenu);
    }

    /// <summary>
    /// Executes the current turn in the battle, alternating between the heroes and monsters.
    /// </summary>
    /// <remarks>This method determines which party's turn it is and delegates the turn execution to the
    /// appropriate player controller. After the turn is executed, the turn alternates to the other party.</remarks>
    public void ExecuteTurn()
    {
        Player heroController = _heroParty.Controller;
        Player monsterController = _monsterParty.Controller;

        if (_currentTurn == CurrentTurn.Heroes)
            heroController.TakeTurn(_battleMenu, _heroParty, _turnHandler);
        else
            monsterController.TakeTurn(_battleMenu, _monsterParty, _turnHandler);

        _currentTurn = _currentTurn == CurrentTurn.Heroes ? CurrentTurn.Monsters : CurrentTurn.Heroes;
    }

    public IReadOnlyList<IBattleEntity> GetHeroEntities() => _heroParty.Entities;
    public IReadOnlyList<IBattleEntity> GetMonsterEntities() => _monsterParty.Entities;
}