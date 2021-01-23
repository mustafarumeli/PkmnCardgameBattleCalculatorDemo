using BattleCalculatorDemo.Models;
using NUnit.Framework;

namespace BattleCalculatorDemo.Test
{
    public class BattleTests
    {
        private Card _attackerCard;
        private Card _defenderCard;

        [SetUp]
        public void SetUp()
        {
            var hardShell = new HardShellAttribute(25);
            var sharper = new SharperAttributeVariable();
            var weightless = new WeightlessAttributeVariable(0, 100);
            var ironWill = new IronWillAttributeVariable();


            _attackerCard = new Card()
            {
                Name = "Mountain Ranger",
                Atk = 25,
                Hp = 50,
                Def = 125
            };
            _defenderCard = new Card()
            {
                Name = "Mountain Ranger",
                Atk = 25,
                Hp = 50,
                Def = 125
            };
            _attackerCard.Attributes.Add(sharper);
            _defenderCard.Attributes.Add(ironWill);
        }

        [Test]
        public void ShouldIncreaseAttackersHpBy25()
        {
            _attackerCard.Attacks(_defenderCard);
            Assert.AreNotEqual(_defenderCard.Hp, 75);
        }
        [Test]
        public void HitChanceShouldRevert()
        {
            _attackerCard.Attacks(_defenderCard);
            Assert.AreEqual(_attackerCard.HitChance, 75);
        }

        [Test]
        public void ShouldTakeNoDamage()
        {
            _attackerCard.Attacks(_defenderCard);
            Assert.AreEqual(50, _defenderCard.Hp);
        }
    }
}