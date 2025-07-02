public class HumanPlayer : Player
{
    public override IBattleCommand InputActionChoice(IBattleEntity entity, Battle battle)
    {
        IReadOnlyList<IBattleEntity> targets = battle.GetAllBattleEntities();
        List<IBattleCommand> commands = entity.BattleCommands;
        int index = Convert.ToInt32(Console.ReadLine());
        return commands[index - 1];
    }
}