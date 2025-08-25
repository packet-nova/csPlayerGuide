namespace Level52TheFinalBattle.Battle
{
    public record BattleData
    {
        public required BattleParty HeroParty { get; set; }
        public required BattleParty MonsterParty { get; set; }
    }
}
