using BattleCalculatorDemo.Models;
using NUnit.Framework;

namespace BattleCalculatorDemo.Test
{
    public class Tests
    {
        private AttributeVariable attributeVariable;
        private Card _attackerCard;
        private Card _defenderCard;
        [SetUp]
        public void Setup()
        {
            CardAttribute hardShell = new CardAttribute();
            hardShell.Name = "Hard Shell";
            hardShell.Description = "When {Name} survives an attack Restore {0}% of Health";
            hardShell.AttributeVariables.Add(new AttributeVariable()
            {
                CardPropertyToAffect = "Hp",
                Value = 25,
                TriggerAttributeOn = AttributeTriggers.AfterDefence,
                ScaleType = ScaleType.Ratio
            });
            _attackerCard.Attributes.Add(hardShell);


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

            _defenderCard.Attributes.Add(hardShell);

        }

        [Test]
        public void IsCardPropertiesCorrect()
        {
            Assert.That(attributeVariable.ToString() == "Hp,Atk,Def,CriticalChance,HitChance");
        }

        [Test]
        public void IsDescriptionCorrect()
        {
            Assert.That(_attackerCard.Description == "Hard Shell 25,");
        }



    }

    public class BattleTests
    {
        private AttributeVariable attributeVariable;
        private Card _attackerCard;
        private Card _defenderCard;

        [SetUp]
        public void SetUp()
        {
            CardAttribute hardShell = new CardAttribute();
            hardShell.Name = "Hard Shell";
            hardShell.Description = "When {Name} survives an attack Restore {0}% of Health";
            hardShell.AttributeVariables.Add(new AttributeVariable()
            {
                CardPropertyToAffect = "Hp",
                Value = 25,
                TriggerAttributeOn = AttributeTriggers.BeforeAttack,
                ScaleType = ScaleType.Direct
            });


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
            _defenderCard.Attributes.Add(hardShell);
        }

        [Test]
        public void ShouldIncreaseAttackersHpBy25()
        {
            _attackerCard.Attacks(_defenderCard);
            Assert.AreEqual(_attackerCard.Hp, 75);
        }

    }
}