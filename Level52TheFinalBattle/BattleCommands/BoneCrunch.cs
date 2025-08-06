public class BoneCrunch : IBattleCommand
{
    public ActionType Category => ActionType.Attack;

    public string DisplayName => "Bone Crunch";

    public bool RequiresTarget { get; } = true;

    public int BaseDamage
    {
        get
        {
            Random random = new();
            return random.Next(2);
        }
    }

    public void Execute() { }
}