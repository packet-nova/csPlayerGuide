public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }

    public void TakeTurn(BattleMenu menu, List<IBattleEntity> party)
    {
        foreach (var entity in party)
        {
            Console.WriteLine();
            Console.WriteLine($"It is {entity.Name}'s turn.");

            if (PlayerType == PlayerType.Human)
            {
                menu.DisplayMenu();
            }

            BattleAction action = menu.AvailableActions[PlayerInputChoice() - 1];
            var command = BattleCommandFactory.PlayerCommand(action);
            command.Execute(entity);
        }
    }

    private int PlayerInputChoice()
    {
        if (PlayerType == PlayerType.Computer)
        {
            return 1;
        }

        return Convert.ToInt32(Console.ReadLine());

    }
}

public enum PlayerType { Human, Computer }