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

    public void TurnTracker()
    {
        if (CurrentTurn == _heroParty)
            HeroPartyTurn();
        else
            MonsterPartyTurn();

        CurrentTurn = CurrentTurn == _heroParty ? _monsterParty : _heroParty;
    }
    public void HeroPartyTurn()
    {
        foreach (var member in _heroParty)
        {
            Console.WriteLine();
            Console.WriteLine($"It is {member.Name}'s turn.");
            CombatMenu.DisplayMenu();
        }
    }

    public void MonsterPartyTurn()
    {
        foreach (var member in _monsterParty)
        {
            Console.WriteLine();
            Console.WriteLine($"It is {member.Name}'s turn.");
            CombatMenu.DisplayMenu();
        }
    }
}