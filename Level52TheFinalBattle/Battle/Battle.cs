using Level52TheFinalBattle.BattleEntities;
using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.Item;
using System.Threading.Tasks.Sources;

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

        public static Battle SingleSkeletonBattle(
        TrueProgrammer trueProgrammer,
        Player heroPlayer,
        Player monsterPlayer)
        {
            var skeleton = new Skeleton();
            var heroParty = new BattleParty([trueProgrammer], heroPlayer);
            var monsterParty = new BattleParty([skeleton], monsterPlayer);
            var consoleLogger = new ConsoleLogger();
            skeleton.EquippedItems.Add  (new Dagger());

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
                
                HandleDead();
            }

            if (_monsterParty.IsEmpty)
            {
                _consoleLogger.PlayerWinBattle();
            }
            else if (_heroParty.IsEmpty)
            {
                _consoleLogger.PlayerLoseBattle();
            }

            Console.Write("Press a key to continue...");
            Console.ReadKey();
            Console.Clear();

            _currentParty = enemyParty;
        }

        public void HumanPlayerTurn(IBattleEntity source)
        {
            var enemyParty = _currentParty == _heroParty ? _monsterParty : _heroParty;
            var actionType = _inputHandler.SelectActionCategory();

            switch (actionType)
            {
                case ActionType.Attack:
                    var attackChoice = _inputHandler.SelectFromList(source.BattleCommands, command => command.Name);

                    if (attackChoice.RequiresTarget)
                    {
                        var target = SelectFromAllList();
                        attackChoice.Execute(source, target);
                    }

                    else
                    {
                        Console.WriteLine($"{source.Name} uses {attackChoice.Name}.");
                    }

                    break;

                case ActionType.Item:
                    var itemChoice = _inputHandler.SelectFromList(_currentParty.Items, item => item.Name);

                    if (itemChoice is IHealing healingItem)
                    {
                        var target = SelectFromAllList();

                        healingItem.Execute(target);
                        _currentParty.Items.Remove((InventoryItem)itemChoice);
                    }

                    break;

                case ActionType.EquipItem:
                    var equipmentChoice = _inputHandler.SelectFromList(_currentParty.Items.OfType<IEquippable>(), equipment => equipment.Name);

                    if (equipmentChoice != null)
                    {
                        _currentParty.Items.Remove((InventoryItem)equipmentChoice);
                        source.EquipGear(equipmentChoice, GetPartyFor(source));
                    }

                    else
                    {
                        HumanPlayerTurn(source);
                        return;
                    }

                    break;

                case ActionType.Nothing:
                    Console.WriteLine($"{source.Name} does nothing.");
                    break;
            }
        }

        public void ComputerPlayerTurn(IBattleEntity source)
        {
            Random rng = new();
            var enemyParty = _currentParty == _heroParty ? _monsterParty : _heroParty;
            var party = GetPartyFor(source);
            bool halfChance = rng.Next(2) == 0; // 50% chance
            
            bool isEquipped = false;
            if (source is Character character)
            {
                isEquipped = character.IsEquipped;
            }
            
            bool shouldHeal = source.CurrentHP <= source.MaxHP / 2
                              && party.Items.Any(item => item is HealingPotion)
                              && rng.Next(4) == 0; // 25% chance

            if (!isEquipped && halfChance && party.Items.OfType<IEquippable>().Any())
            {
                var equipChoice = party.Items.OfType<IEquippable>().First();
                source.EquipGear(equipChoice, GetPartyFor(source));
            }

            else if (shouldHeal && party.Items.OfType<HealingPotion>().Any())
            {
                var healPotion = party.Items.OfType<HealingPotion>().First();
                healPotion.Execute(source);
                party.Items.Remove(healPotion);
            }

            else if (source.BattleCommands.Count > 0)
            {
                var targetIndex = rng.Next(enemyParty.Entities.Count);
                var target = enemyParty.Entities[targetIndex];
                IBattleCommand attackChoice = source.BattleCommands[rng.Next(source.BattleCommands.Count)];
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

        public IBattleEntity SelectFromHeroList() => _inputHandler.SelectFromList(
            this.HeroEntities,
            entity => $"{entity.Name} HP: {entity.CurrentHP}/{entity.MaxHP}");

        public IBattleEntity SelectFromMonsterList() => _inputHandler.SelectFromList(
            this.MonsterEntities,
            entity => $"{entity.Name} HP: {entity.CurrentHP}/{entity.MaxHP}");

        public IBattleEntity SelectFromAllList() => _inputHandler.SelectFromList(
            this.AllBattleEntities,
            entity => $"{entity.Name} HP: {entity.CurrentHP}/{entity.MaxHP}");
    }
}