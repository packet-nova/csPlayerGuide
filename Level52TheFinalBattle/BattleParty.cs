public class BattleParty
{
    public List<IBattleEntity> Entities { get; }
    public Player PlayerController { get; }

    public BattleParty(List<IBattleEntity> entities, Player controller)
    {
        Entities = entities;
        PlayerController = controller;
    }
}