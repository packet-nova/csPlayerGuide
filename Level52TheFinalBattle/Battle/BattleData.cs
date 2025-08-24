namespace Level52TheFinalBattle.Battle
{
    public record BattleData{
        public BattleParty HeroParty { get; init; }
        public BattleParty MonsterParty { get; }
    }
}
