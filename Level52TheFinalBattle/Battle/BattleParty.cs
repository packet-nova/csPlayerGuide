using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.Battle
{
    public class BattleParty
    {
        public List<IBattleEntity> Entities { get; }

        public Player Controller { get; }

        public bool IsEmpty => Entities.Count == 0;

        public List<InventoryItem> Items { get; } = [];

        public BattleParty(List<IBattleEntity> entities, Player controller)
        {
            Entities = entities;
            Controller = controller;
        }
    }
}