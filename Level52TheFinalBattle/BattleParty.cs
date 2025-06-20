public class BattleParty
{
    public List<IBattleEntity> Entities { get; }
    public Player Controller { get; }

    public BattleParty(List<IBattleEntity> entities, Player controller)
    {
        Entities = entities;
        Controller = controller;
    }
}