public class BattleGenerator
{
    public static BattleData CreateBasicSkeletonBattle(TrueProgrammer trueProgrammer)
    {
        Player heroPlayer = new(PlayerType.Human);
        Player monsterPlayer = new(PlayerType.Computer);

        Skeleton skeleton = new Skeleton();

        var heroParty = new BattleParty(
            new List<IBattleEntity> { trueProgrammer },
            heroPlayer
            );
        var monsterParty = new BattleParty(
            new List<IBattleEntity> { skeleton },
            monsterPlayer
            );

        return new BattleData(
            HeroParty: heroParty,
            MonsterParty: monsterParty,
            FirstTurn: CurrentTurn.Heroes
            );
    }
}