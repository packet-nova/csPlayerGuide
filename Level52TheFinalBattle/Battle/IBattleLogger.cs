using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.Battle
{
    public interface IBattleLogger
    {
        void LogMessage(string message);
        void TurnNotification(IBattleEntity entity);
        void LogKill(IBattleEntity entity);
        void PlayerWinBattle();
        void PlayerLoseBattle();
        void StatusBanner(Battle battle);
    }
}