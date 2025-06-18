public class Game
{
    private readonly List<ICombat> _heroParty = new List<ICombat>();
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    public TrueProgrammer TrueProgrammer { get; private set; }
    public Combat CurrentCombat { get; private set; }

    public Game(Player heroPlayer, Player monsterPlayer)
    {
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
        TrueProgrammer = new(CreateTrueProgrammer());
        _heroParty.Add(TrueProgrammer);
        StartCombat();
    }

    public void Run()
    {
        while (true)
        {
            CurrentCombat.TurnTracker(_heroPlayer, _monsterPlayer);
        }
    }

    public void StartCombat()
    {
        var monsterParty = new List<ICombat> { new Skeleton() };
        CombatMenu menu = new();
        CurrentCombat = new(_heroParty, monsterParty, menu);
    }

    public string CreateTrueProgrammer()
    {
        Console.Write("What is the True Programmer's name? ");
        return Console.ReadLine();
    }
}
