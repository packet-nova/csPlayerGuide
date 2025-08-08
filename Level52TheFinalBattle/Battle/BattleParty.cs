public class BattleParty
{
    public List<IBattleEntity> Entities { get; }
    /// <summary>
    /// Gets the player that controls the current entity.
    /// </summary>
    public Player Controller { get; }
    /// <summary>
    /// Returns a bool indicating whether the this Battle Party contains any entities.
    /// </summary>
    public bool IsEmpty => Entities.Count == 0;

    public BattleParty(List<IBattleEntity> entities, Player controller)
    {
        Entities = entities;
        Controller = controller;
    }
}