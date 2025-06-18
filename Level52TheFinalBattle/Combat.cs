public class Combat
{
    private readonly List<ICombat> _heroParty;
    private readonly List<ICombat> _monsterParty;

    public CombatMenu CombatMenu { get; private set; }
    public List<ICombat> CurrentTurn { get; private set; }

    public Combat(List<ICombat> heroParty, List<ICombat> monsterParty, CombatMenu menu)
    {
        _heroParty = heroParty;
        _monsterParty = monsterParty;
        CombatMenu = menu;
        CurrentTurn = _heroParty;
    }

    public void TurnTracker(Player heroPlayer, Player monsterPlayer)
    {
        if (CurrentTurn == _heroParty)
            heroPlayer.TakeTurn(CombatMenu, _heroParty);
        else
            monsterPlayer.TakeTurn(CombatMenu, _monsterParty);

        CurrentTurn = CurrentTurn == _heroParty ? _monsterParty : _heroParty;
    }
}