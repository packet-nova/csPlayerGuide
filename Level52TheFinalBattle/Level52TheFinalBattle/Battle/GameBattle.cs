
using Level52TheFinalBattle.Entities;

namespace Level52TheFinalBattle.Battle;

public class GameBattle
{
    public required List<IGameEntity> HeroParty { get; set; } = [];

    public required List<IGameEntity> MonsterParty { get; set; } = [];

    public required List<ICombatLogEntry> CombatLogEntry { get; set; } = [];

    /// <summary>
    /// Executes a combat turn for a single game entity
    /// </summary>
    /// <param name="sourceEntity">The entity taking the turn</param>
    public void TakeTurn(IGameEntity sourceEntity)
    {
        // determine if this entity is a hero or monster
        var isHero = HeroParty.Contains(sourceEntity);

        // The "enemy party" is subjective -- when this is a hero entity,
        // then the enemy is the monster party, and vice versa
        var enemyParty = isHero ? MonsterParty : HeroParty;

        // Determine the action this entity should perform
        IBattleAction selectedAction;

        // Display a menu of available actions when controlled by a human
        if (sourceEntity.ControlledBy == ControlledBy.Human)
        {
            for (var index = 0; index < sourceEntity.Actions.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {sourceEntity.Actions[index]}");
            }

            Console.Write($"What Action? (1-{sourceEntity.Actions.Count}): ");

            // Get user action choice
            var isValidActionChoice = int.TryParse(Console.ReadLine(), out var actionChoice) &&
                                      (actionChoice is > 0 && actionChoice <= sourceEntity.Actions.Count);

            while (isValidActionChoice == false)
            {
                Console.WriteLine("Invalid entry.");
                Console.Write($"What Action? (1-{sourceEntity.Actions.Count}): ");

                isValidActionChoice = int.TryParse(Console.ReadLine(), out actionChoice) &&
                                      (actionChoice is > 0 && actionChoice <= sourceEntity.Actions.Count);
            }

            // Assigning action choice
            selectedAction = sourceEntity.Actions[actionChoice - 1];
        }
        else
        {
            // randomly select an action when this entity is controlled by the computer
            var rng = new Random();
            selectedAction = sourceEntity.Actions[rng.Next(sourceEntity.Actions.Count)];
        }

        // Determine the target for the action
        IGameEntity selectedTarget;

        // Display menu of available targets when controlled by a human
        if (sourceEntity.ControlledBy == ControlledBy.Human)
        {
            for (var index = 0; index < enemyParty.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {enemyParty[index]}");
            }

            // Get user target choice
            Console.Write($"What target? (1-{enemyParty.Count}): ");

            var isValidTargetChoice = int.TryParse(Console.ReadLine(), out var targetChoice) &&
                                      (targetChoice > 0 && targetChoice <= enemyParty.Count);

            while (isValidTargetChoice == false)
            {
                Console.WriteLine("Invalid entry.");
                Console.Write($"What target? (1-{enemyParty.Count}): ");

                isValidTargetChoice = int.TryParse(Console.ReadLine(), out targetChoice) &&
                                      (targetChoice > 0 && targetChoice <= enemyParty.Count);
            }

            // Assigning target choice
            selectedTarget = enemyParty[targetChoice - 1];
        }
        else
        {
            // randomly select a target when this entity is controlled by the computer
            var rng = new Random();
            selectedTarget = enemyParty[rng.Next(enemyParty.Count)];
        }

        // Create the Combat Log entry for this turn
        var logEntry = new CombatLogEntry
        {
            SourceEntity = sourceEntity,
            TargetEntity = selectedTarget,
            ActionPerformed = selectedAction
        };

        CombatLogEntry.Add(logEntry);

        Console.WriteLine(logEntry);
        Console.WriteLine();
    }
}
