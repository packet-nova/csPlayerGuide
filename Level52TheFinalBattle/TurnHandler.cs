public class TurnHandler
{
    private BattleMenu _menu;

    public TurnHandler(BattleMenu menu)
    {
        _menu = menu;
    }

    /// <summary>
    /// Executes the turn for a specified battle entity, allowing the player to choose an action if applicable.
    /// </summary>
    /// <remarks>If the player is human, an action menu is displayed to allow the player to select an action.
    /// The selected action is then executed for the specified entity.</remarks>
    /// <param name="entity">The battle entity whose turn is being executed.</param>
    /// <param name="player">The player controlling the entity, which determines the interaction type.</param>
    public void ExecuteEntityTurn(IBattleEntity entity, Player player)
    {
        _menu.PrintEntityTurnNotification(entity);

        if (player.PlayerType == PlayerType.Human)
        {
            _menu.PrintActionMenu();
        }

        BattleAction choice = _menu.AvailableActions[player.InputActionChoice() - 1];
        
        var command = BattleCommandFactory.PlayerCommand(choice);
        command.Execute(entity);
    }
}