using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.Battle
{
    public class BattleParty
    {
        /// <summary>
        /// Gets the collection of battle entities currently managed by the system.
        /// </summary>
        public List<IBattleEntity> Entities { get; }

        /// <summary>
        /// Gets the player that controls the current entity.
        /// </summary>
        public Player Controller { get; }

        /// <summary>
        /// Returns a bool indicating whether the this Battle Party contains any entities.
        /// </summary>
        public bool IsEmpty => Entities.Count == 0;

        public List<InventoryItem> Items = [];

        public BattleParty(List<IBattleEntity> entities, Player controller)
        {
            Entities = entities;
            Controller = controller;
        }
    }
}