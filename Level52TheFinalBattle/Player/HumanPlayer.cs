public class HumanPlayer : Player
{
    public override IBattleCommand InputActionChoice(IBattleEntity entity, Battle battle)
    {
        IReadOnlyList<IBattleEntity> targets = battle.GetAllEntities();
        List<IBattleCommand> commands = entity.GetAvailableCommands(battle);
        int index = Convert.ToInt32(Console.ReadLine());
        return commands[index - 1];
    }
}