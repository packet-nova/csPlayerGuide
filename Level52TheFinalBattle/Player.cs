public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player (PlayerType playerType)
    {
        PlayerType = playerType;
    }
}

public enum PlayerType { Human, Computer }