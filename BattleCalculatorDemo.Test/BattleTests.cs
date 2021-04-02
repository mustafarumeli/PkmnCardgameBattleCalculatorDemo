using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.BoardManager;
using BattleCalculatorDemo.BoardManager.Entities;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.Helpers;
using BattleCalculatorDemo.Cards.ItemCards.Polymorph;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;
using NUnit.Framework;
using static BattleCalculatorDemo.API.Hubs.GameManagerHub;

namespace BattleCalculatorDemo.Test
{
    [TestFixture]
    public class GameTests
    {
        RoomManager roomManagerInstance;
        RoomHub room;
        Player player1, player2;
        IBoardManager boardManager;

        [SetUp]
        public void Setup()
        {
            roomManagerInstance = new RoomManager();
            room = new RoomHub();
            player1 = new Player
            {
                ConnectionId = Guid.NewGuid().ToString(),
                PlayerInGame = new PlayerInGame()
                {
                    Name = Guid.NewGuid().ToString(),
                    Side = PlayerSide.Blue,
                    CardsInHand = new List<ICard>(),
                    Deck = CardHelpers.GetAllTierOneCards()
                }
            };
            player2 = new Player
            {
                ConnectionId = Guid.NewGuid().ToString(),
                PlayerInGame = new PlayerInGame()
                {
                    Name = Guid.NewGuid().ToString(),
                    Side = PlayerSide.Red,
                    CardsInHand = new List<ICard>(),
                    Deck = CardHelpers.GetAllTierOneCards()
                }
            };
            room.Player1 = player1;
            room.Player2 = player2;

            boardManager = BoardManagerObject.CreateBoardManager(player1.PlayerInGame, player2.PlayerInGame);

            room = new RoomHub
            {
                BoardManager = boardManager,
                Player1 = player1,
                Player2 = player2
            };


        }
        public void Player1GetsHand()
        {
            room.Player1.PlayerInGame.CardsInHand = room.Player1.GetHand(6).Select(x => x as ICard).ToList();
        }
        public void Player2GetsHand()
        {
            room.Player2.PlayerInGame.CardsInHand = room.Player2.GetHand(5).Select(x => x as ICard).ToList();
        }
        public void Player1PlaysCard()
        {
            room.BoardManager.Player1PlayCard(room.Player1.PlayerInGame.CardsInHand.First().Id);

        }

        public void Player2PlaysCard()
        {
            room.BoardManager.Player2PlayCard(room.Player2.PlayerInGame.CardsInHand.First().Id);
        }

        public ICombatResult Player1AttacksPlayer2()
        {
            var attackerId = room.Player1.PlayerInGame.CardsInHand.First().Id;
            var defenderId = room.Player2.PlayerInGame.CardsInHand.First().Id;
            return room.BoardManager.Battle(attackerId, defenderId);
        }
        [Test]
        public void Basic2TurnScenrio()
        {
            Player1GetsHand();
            Player2GetsHand();
            Player1PlaysCard();
            Player2PlaysCard();
            var result = Player1AttacksPlayer2();
            Assert.IsTrue(result.DidDefenderDie == true);
        }

    }
    public class BattleTests
    {
        private MonsterCard _attackerMonsterCard;
        private MonsterCard _defenderMonsterCard;
        private Polymorpher _polymorpher;
        private Depolymorpher _depolymorpher;
        private PolymorphedMonsterCard _polymorphedMonster;
        public static IEnumerable<Type> GetTypesWithMyAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (Attribute.IsDefined(type, typeof(CardAttributeStatusAttribute)))
                    yield return type;
            }
        }
        [SetUp]
        public void SetUp()
        {
            var asmbly = Assembly.GetExecutingAssembly();
            var types = GetTypesWithMyAttribute(asmbly);
            types.ToArray();
            var hardShell = new HardShellCardAttribute(25);
            var hardShell2 = new HardShellCardAttribute(50);
            var sharper = new SharperCardAttribute();
            var weightless = new WeightlessCardAttribute(0, 100);
            var ironWill = new IronWillCardAttribute();


            _attackerMonsterCard = new MountainRangerCard()
            {
                Atk = 25,
                Hp = 50,
                Def = 125
            };
            _defenderMonsterCard = new MountainRangerCard()
            {
                Atk = 25,
                Hp = 50,
                Def = 125
            };
            _attackerMonsterCard.Attributes.Add(hardShell);
            _defenderMonsterCard.Attributes.Add(weightless);
            _defenderMonsterCard.Attributes.Add(hardShell2);

            _attackerMonsterCard.AddTypes(new PaperMonsterType(), new RockMonsterType());
            _defenderMonsterCard.AddTypes(new ScissorsMonsterType());
            _polymorpher = new Polymorpher();
            _depolymorpher = new Depolymorpher();
            _polymorphedMonster = _polymorpher.Polymorph(_attackerMonsterCard, _defenderMonsterCard);
        }

        [Test]
        public void ShouldIncreaseAttackersHpBy25()
        {
            _attackerMonsterCard.Attacks(_defenderMonsterCard);
            Assert.AreNotEqual(_defenderMonsterCard.Hp, 75);
        }
        [Test]
        public void HitChanceShouldRevert()
        {
            _attackerMonsterCard.Attacks(_defenderMonsterCard);
            Assert.AreEqual(_attackerMonsterCard.HitChance, 75);
        }

        [Test]
        public void ShouldTakeNoDamage()
        {
            _attackerMonsterCard.Attacks(_defenderMonsterCard);
            Assert.AreEqual(50, _defenderMonsterCard.Hp);
        }

        [Test]
        public void TypeNameShouldBeCorrect()
        {
            Assert.AreEqual("Paper,Rock", _attackerMonsterCard.GetTypeNames());
        }

        [Test]
        public void ShouldPolymorph()
        {
            var polymorphedCard = _polymorpher.Polymorph(_attackerMonsterCard, _defenderMonsterCard);
            Assert.That(polymorphedCard != null);
        }

        [Test]
        public void ShouldDepolymorph()
        {
            var depolyMorphed = _depolymorpher.Depolymorph(ref _polymorphedMonster);
            Assert.That(depolyMorphed != null);
        }
    }
}