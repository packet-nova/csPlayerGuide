using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;

namespace Level52TheFinalBattle.Battle
{
    public class Battle
    {
        private readonly BattleParty _heroParty;
        private readonly BattleParty _monsterParty;
        private readonly IBattleLogger _consoleLogger;
        private readonly InputHandler _inputHandler;
        private BattleParty _currentParty;

        public IBattleEntity? CurrentEntity { get; private set; }
        public IReadOnlyList<IBattleEntity> AllBattleEntities => [.. MonsterEntities, .. HeroEntities];
        public IReadOnlyList<IBattleEntity> HeroEntities => _heroParty.Entities;
        public IReadOnlyList<IBattleEntity> MonsterEntities => _monsterParty.Entities;
        public bool IsActive => !_heroParty.IsEmpty && !_monsterParty.IsEmpty;

        public Battle(BattleParty heroParty, BattleParty monsterParty, IBattleLogger logger)
        {
            _heroParty = heroParty;
            _monsterParty = monsterParty;
            _currentParty = heroParty;
            _consoleLogger = logger;
            _inputHandler = new InputHandler();
            _heroParty.Items.Add(new LesserHealingPotion());
            _heroParty.Items.Add(new LesserHealingPotion());
            _heroParty.Items.Add(new LesserHealingPotion());
            _monsterParty.Items.Add(new LesserHealingPotion());
        }

        /// <summary>
        /// Creates a basic battle scenario between a hero and a skeleton monster.
        /// </summary>
        public static Battle SingleSkeletonBattle(
        TrueProgrammer trueProgrammer,
        Player heroPlayer,
        Player monsterPlayer)
        {
            var skeleton = new Skeleton();
            var heroParty = new BattleParty([trueProgrammer], heroPlayer);
            var monsterParty = new BattleParty([skeleton], monsterPlayer);
            var consoleLogger = new ConsoleLogger();
            skeleton.EquipGear(new Dagger());

            return new Battle(heroParty, monsterParty, consoleLogger);
        }

        public static Battle TwoSkeletonBattle(
        TrueProgrammer trueProgrammer,
        Player heroPlayer,
        Player monsterPlayer)
        {
            var skeleton = new Skeleton();
            var skeleton2 = new Skeleton();
            var heroParty = new BattleParty([trueProgrammer], heroPlayer);
            var monsterParty = new BattleParty([skeleton, skeleton2], monsterPlayer);
            var consoleLogger = new ConsoleLogger();

            monsterParty.Items.Add(new Dagger());
            monsterParty.Items.Add(new Dagger());

            return new Battle(heroParty, monsterParty, consoleLogger);
        }
        public static Battle ZombieBattle(
        TrueProgrammer trueProgrammer,
        Player heroPlayer,
        Player monsterPlayer)
        {
            var zombie = new Zombie();
            var heroParty = new BattleParty([trueProgrammer], heroPlayer);
            var monsterParty = new BattleParty([zombie], monsterPlayer);
            var consoleLogger = new ConsoleLogger();

            return new Battle(heroParty, monsterParty, consoleLogger);
        }

        public static Battle CodedOneBattle(
        TrueProgrammer trueProgrammer,
        Player heroPlayer,
        Player monsterPlayer)
        {
            var codedOne = new TheCodedOne();
            var heroParty = new BattleParty([trueProgrammer], heroPlayer);
            var monsterParty = new BattleParty([codedOne], monsterPlayer);
            var consoleLogger = new ConsoleLogger();

            return new Battle(heroParty, monsterParty, consoleLogger);
        }

        /// <summary>
        /// Executes a single turn in the battle, allowing each entity in the active party to perform an action.
        /// </summary>
        public void ExecuteTurn()
        {
            // The enemy party is relative to the current active party.
            // If the current active party is _heroParty, the enemy party is _monsterParty and vice-versa.
            var enemyParty = _currentParty == _heroParty ? _monsterParty : _heroParty;

            foreach (var entity in _currentParty.Entities)
            {
                CurrentEntity = entity;

                if (_currentParty.Controller is HumanPlayer)
                {
                    _consoleLogger.StatusBanner(this);
                    HumanPlayerTurn(entity);
                }
                else
                {
                    ComputerPlayerTurn(entity);
                }
            }

            HandleDead();

            if (_monsterParty.IsEmpty)
            {
                _consoleLogger.PlayerWinBattle();
            }
            else if (_heroParty.IsEmpty)
            {
                _consoleLogger.PlayerLoseBattle();
            }

            _currentParty = enemyParty;
        }

        public void HumanPlayerTurn(IBattleEntity source)
        {
            var actionType = _inputHandler.SelectActionCategory();

            switch (actionType)
            {
                case ActionType.Attack:
                    var attackChoice = _inputHandler.SelectAttack(source);

                    if (attackChoice.RequiresTarget)
                    {
                        var target = _inputHandler.SelectTarget(AllBattleEntities);
                        attackChoice.Execute(source, target);
                    }
                    else
                    {
                        Console.WriteLine($"{source.Name} uses {attackChoice.Name}.");
                    }
                    break;
                
                case ActionType.Item:
                    var itemChoice = _inputHandler.SelectItem(_currentParty);

                    if (itemChoice is IHealing healingItem)
                    {
                        var target = _inputHandler.SelectTarget(AllBattleEntities);
                        healingItem.Execute(target);
                        _currentParty.Items.Remove(itemChoice);
                    }
                    break;
                
                case ActionType.Nothing:
                    Console.WriteLine($"{source.Name} does nothing.");
                    break;
            }
        }

        public void ComputerPlayerTurn(IBattleEntity source)
        {
            var enemyParty = _currentParty == _heroParty ? _monsterParty : _heroParty;
            var party = GetPartyFor(source);
            
            Random rng = new();
            
            bool shouldHeal = source.CurrentHP <= source.MaxHP / 2
                              && party.Items.Any(item => item is HealingPotion)
                              && rng.Next(4) == 0; // 25% chance

            if (shouldHeal)
            {
                var healPotion = party.Items.OfType<HealingPotion>().First();
                healPotion.Execute(source);
                party.Items.Remove(healPotion);
            }

            else if (source.BattleCommands.Count > 0)
            {
                var targetIndex = rng.Next(enemyParty.Entities.Count);
                var target = enemyParty.Entities[targetIndex];
                IBattleCommand attackChoice = source.BattleCommands[0];
                attackChoice.Execute(source, target);
            }
            
            else
            {
                Console.WriteLine($"{source.Name} does nothing.");
            }
        }

        public BattleParty GetPartyFor(IBattleEntity entity) => HeroEntities.Contains(entity) ? _heroParty : _monsterParty;

        public void HandleDead()
        {
            foreach (var entity in AllBattleEntities)
            {
                if (entity.IsDead)
                {
                    _consoleLogger.LogKill(entity);
                    GetPartyFor(entity).Entities.Remove(entity);
                }
            }
        }
    }
}