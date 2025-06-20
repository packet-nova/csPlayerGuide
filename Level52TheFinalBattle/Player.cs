public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }

    public void TakeTurn(BattleMenu menu, BattleParty party)
    {
        foreach (var entity in party.Entities)
        {
            menu.PrintEntityTurnNotification(entity);
            
            if (PlayerType == PlayerType.Human)
            {
                menu.PrintActionMenu();
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

