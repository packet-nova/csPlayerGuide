public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }

    public void TakeTurn(CombatMenu menu, List<ICombat> party)
    {
        foreach (var member in party)
        {
            Console.WriteLine();
            Console.WriteLine($"It is {member.Name}'s turn.");
            
            if (PlayerType == PlayerType.Human)
                menu.DisplayMenu();

            if (PlayerInputChoice() == 1)
                member.DoNothing();
        }
    }

    private int PlayerInputChoice()
    {
        if (PlayerType == PlayerType.Computer)
            return 1;

        return Convert.ToInt32(Console.ReadLine());

    }
}

public enum PlayerType { Human, Computer }