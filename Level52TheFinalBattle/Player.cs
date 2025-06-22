public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }

    public int InputActionChoice()
    {
        if (PlayerType == PlayerType.Computer)
        {
            return 1;
        }

        return Convert.ToInt32(Console.ReadLine());
    }
}

