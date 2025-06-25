public class HumanPlayer : Player
{
    public override IBattleCommand InputActionChoice(IBattleEntity entity, Battle battle)
    {
        List<IBattleCommand> commands = entity.GetAvailableCommands(battle);
        int index = Convert.ToInt32(Console.ReadLine());
        return commands[index - 1];
    }
}