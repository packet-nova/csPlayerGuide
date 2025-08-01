public class Punch : IBattleCommand
{
    public ActionType Category => ActionType.Attack;

    public void Execute(IBattleEntity source)
    {
        throw new NotImplementedException();
    }

    public string GetDisplayName(IBattleEntity entity)
    {
        throw new NotImplementedException();
    }

    public override string ToString() => "Punch";
}
