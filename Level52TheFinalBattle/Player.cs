public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }

    public IBattleCommand InputActionChoice(IBattleEntity entity, Battle battle)
    {
        List<IBattleCommand> commands = entity.GetAvailableCommands(battle);
        if (PlayerType == PlayerType.Computer)
        {
            return commands[0];
        }

        int index = Convert.ToInt32(Console.ReadLine());
        return commands[index - 1];
    }
}

