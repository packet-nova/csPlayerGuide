public abstract class Player
{
    /// <summary>
    /// Selects and returns the battle command to be executed by the specified entity during the battle by the computer or human player.
    /// </summary>
    public abstract IBattleCommand InputActionChoice(IBattleEntity entity, Battle battle);
}
