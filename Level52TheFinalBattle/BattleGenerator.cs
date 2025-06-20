public class BattleGenerator
{
    public static BattleData CreateBasicSkeletonBattle(
        TrueProgrammer trueProgrammer,
        Player heroPlayer,
        Player monsterPlayer
        )
    {
        Skeleton skeleton = new();

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