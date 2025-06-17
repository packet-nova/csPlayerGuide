public class Combat
{
    private readonly List<ICombat> _heroParty;
    private readonly List<ICombat> _monsterParty;

    public CombatMenu CombatMenu { get; private set; }
    public TrueProgrammer TrueProgrammer { get; private set; }
    public List<ICombat> CurrentTurn { get; private set; }

    public Combat(List<ICombat> heroParty, List<ICombat> monsterParty)
    {
        _heroParty = heroParty;
        _monsterParty = monsterParty;
        CurrentTurn = _heroParty;
        CombatMenu = new();
    }

    public void CombatTurn()
    {
        if (CurrentTurn == _heroParty)
        {
            Thread.Sleep(500);
            PlayerPartyTurn();
            Console.WriteLine();
        }
        else
        {
            Thread.Sleep(500);
            MonsterPartyTurn();
            Console.WriteLine();
        }

        CurrentTurn = CurrentTurn == _heroParty ? _monsterParty : _heroParty;
    }
    public void PlayerPartyTurn()
    {
        foreach (var member in _heroParty)
        {
            Console.WriteLine($"It is {member.Name}'s turn.");
            CombatMenu.DisplayMenu();
        }
    }

    public void MonsterPartyTurn()
    {
        foreach (var member in _monsterParty)
        {
            Console.WriteLine($"It is {member.Name}'s turn.");
            CombatMenu.DisplayMenu();
        }
    }
}