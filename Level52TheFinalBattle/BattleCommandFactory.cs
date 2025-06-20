public class BattleCommandFactory
{
    public static IBattleCommand PlayerCommand(BattleAction action) => action switch
    {
        BattleAction.DoNothing => new DoNothing(),
        BattleAction.Attack => new Attack(),
        _ => new DoNothing()
    };
}