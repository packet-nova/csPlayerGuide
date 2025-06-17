public class Game
{
    private readonly List<ICombat> _heroParty = new List<ICombat>();
    private readonly List<ICombat> _monsterParty = new List<ICombat>();
    public TrueProgrammer TrueProgrammer { get; private set; }
    public Combat CurrentCombat { get; private set; }

    public Game()
    {
        TrueProgrammer = new(CreateTrueProgrammer());
        CurrentCombat = new(_heroParty, _monsterParty);
        Skeleton skeleton1 = new("SKELETON");
        _heroParty.Add(TrueProgrammer);
        _monsterParty.Add(skeleton1);
    }

    public void Run()
    {
        while (true)
        {
            CurrentCombat.CombatTurn();
        }
    }

    public string CreateTrueProgrammer()
    {
        Console.Write("What is the True Programmer's name? ");
        return Console.ReadLine();
    }
}
