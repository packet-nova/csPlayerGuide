public class Player
{
    public PlayerType PlayerType { get; init; }

    public Player(PlayerType playerType)
    {
        PlayerType = playerType;
    }

    /// <summary>
    /// Executes a turn for each entity in the specified battle party using the provided turn handler.
    /// </summary>
    /// <remarks>This method iterates through all entities in the given battle party and delegates the
    /// execution of each entity's turn to the specified <paramref name="handler"/>. The order of execution is
    /// determined by the order of entities in the <paramref name="party"/>.</remarks>
    /// <param name="menu">The battle menu that provides options and context for the turn.</param>
    /// <param name="party">The battle party whose entities will take their turns.</param>
    /// <param name="handler">The turn handler responsible for executing each entity's turn logic.</param>
    public void TakeTurn(BattleMenu menu, BattleParty party, TurnHandler handler)
    {
        foreach (var entity in party.Entities)
        {
            handler.ExecuteEntityTurn(entity, this);
        }
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

