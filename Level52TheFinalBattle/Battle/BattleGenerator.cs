namespace Level52TheFinalBattle.Battle
{
    public class BattleGenerator
    {

        public BattleData GenerateBattle(BattleParty heroParty, int battleTier)
        {
            return new BattleData
            {
                HeroParty = heroParty,

            };
        }

    }
}
