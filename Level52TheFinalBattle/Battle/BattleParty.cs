public class BattleParty
{
    public List<IBattleEntity> Entities { get; }
    /// <summary>
    /// Gets the player that controls the current entity.
    /// </summary>
    public Player Controller { get; }

    public BattleParty(List<IBattleEntity> entities, Player controller)
    {
        Entities = entities;
        Controller = controller;
    }
}