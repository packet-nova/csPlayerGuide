public class ComputerPlayer : Player
{
    public override IBattleCommand InputActionChoice(IBattleEntity entity, Battle battle)
    {
        List<IBattleCommand> commands = entity.BattleCommands;
            return commands[0];
        }
    }