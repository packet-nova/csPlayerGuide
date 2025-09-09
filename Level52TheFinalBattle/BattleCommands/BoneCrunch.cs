using Level52TheFinalBattle.BattleEntities;

namespace Level52TheFinalBattle.BattleCommands
{
    public class BoneCrunch : Attack
    {
        public override string Name => "Bone Crunch";
        public override int BaseDamage => _rng.Next(2);
        public override DamageType Type => DamageType.Physical;
    }
}