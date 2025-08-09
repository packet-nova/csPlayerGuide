public class Game
{
    private readonly Player _heroPlayer;
    private readonly Player _monsterPlayer;
    private readonly TrueProgrammer _trueProgrammer;
    private Battle _currentBattle;
    private int _battleTier = 1;

    public Game(TrueProgrammer trueProgrammer, Player heroPlayer, Player monsterPlayer)
    {
        _trueProgrammer = trueProgrammer;
        _heroPlayer = heroPlayer;
        _monsterPlayer = monsterPlayer;
    }

    public void Run()
    {
        while (_battleTier <= 2)
        {
            _currentBattle = _battleTier switch
            {
                1 => Battle.SingleSkeletonBattle(_trueProgrammer, _heroPlayer, _monsterPlayer),
                2 => Battle.TwoSkeletonBattle(_trueProgrammer, _heroPlayer, _monsterPlayer),
                _ => throw new InvalidOperationException($"No battle implemented for battle tier: {_battleTier}.")
            };
            Console.Write("Press a key to begin!");
            Console.ReadKey();
            Console.Clear();
            Console.Write($"Loading battle {_battleTier}");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Console.WriteLine();
            Console.WriteLine();


            while (_currentBattle.IsActive)
            {
                _currentBattle.ExecuteTurn();
            }

            // Check to see if player lost the game
            if (_currentBattle.HeroEntities.Count == 0)
            {
                Console.WriteLine("You lose! Press any key to exit...");
                Console.ReadKey();
            }

            // Player won battle. Go to next battle (tier).
            _battleTier++;
        }
        Console.WriteLine("You won the game. There are no more battles.");
    }
}