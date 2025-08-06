public interface IBattleLogger
{
    void LogMessage(string message);
    void TurnNotification(IBattleEntity entity);
    void LogKill(IBattleEntity entity);
}