using BattleCalculatorDemo.Models;
using BattleCalculatorDemo.Models.CardAttributes;
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
            var hardShell = new HardShellCardAttribute(25);
            var sharper = new SharperCardAttribute();
            var weightless = new WeightlessCardAttribute(0, 100);
            var ironWill = new IronWillCardAttribute();


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
            _attackerCard.Attributes.Add(hardShell);
            _defenderCard.Attributes.Add(weightless);
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