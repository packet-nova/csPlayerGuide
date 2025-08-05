public class DoNothing : IBattleCommand
{
    public ActionType Category => ActionType.Nothing;
    public string DisplayName => "Do Nothing";
    public bool RequiresTarget { get; }

    public void Execute() { }
}