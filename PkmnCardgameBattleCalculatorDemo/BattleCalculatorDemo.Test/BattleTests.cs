﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.Helpers;
using BattleCalculatorDemo.Cards.ItemCards.Polymorph;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;
using NUnit.Framework;

namespace BattleCalculatorDemo.Test
{
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