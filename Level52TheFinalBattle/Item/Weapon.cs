using Level52TheFinalBattle.BattleCommands;

namespace Level52TheFinalBattle.Item
{
    public abstract class Weapon : InventoryItem, IEquippable
    {
        private readonly IBattleCommand _command;
        public IBattleCommand ProvidedCommand => _command;
        
        protected Weapon()
        {
            _command = CreateCommand();
        }
        protected abstract IBattleCommand CreateCommand();
    }
}
