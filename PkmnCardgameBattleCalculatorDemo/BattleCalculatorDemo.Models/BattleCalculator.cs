using System;
using System.Linq;

namespace BattleCalculatorDemo.Models
{
    public static class BattleCalculator
    {

        private const ushort ATTACKDEFENCERATIOMULTIPLER = 50;
        public static void Attacks(this Card attacker, Card defender)
        {
            CalculateBeforeEffects(attacker, defender);

            ushort damage = CalculateDamage(attacker, defender);
            defender.Hp -= damage;
            CalculateAfterEffects(attacker, defender);
        }
        // Damage = IsCritical X Random(1,1.25) X Type Modifier X ((A.Attack / D.Defence) *50)
        private static ushort CalculateDamage(Card attacker, Card defender)
        {
            bool canHitCritical = CalculateCanHitCritical(attacker);
            ushort criticalMultiplier = 1;
            Random rnd = new Random();
            CalculateCriticalMultipler(attacker, canHitCritical, rnd, ref criticalMultiplier);
            ushort randomMultiplier = (ushort)(rnd.Next(100, 125) / 100);
            ushort typeMultiplier = GetTypeMultiplier(attacker, defender);
            return (ushort)(criticalMultiplier * randomMultiplier * typeMultiplier * (attacker.Atk / defender.Def * ATTACKDEFENCERATIOMULTIPLER);
        }

        private static byte GetTypeMultiplier(Card attacker, Card defender)
        {
            return 1;
        }

        private static void CalculateCriticalMultipler(Card attacker, bool canHitCritical, Random rnd, ref ushort criticalMultiplier)
        {
            if (canHitCritical)
            {
                if (attacker.CriticalChance == 100)
                {
                    criticalMultiplier = 2;
                }
                else
                {
                    var randomValForCritical = rnd.Next(0, 100);

                    if (randomValForCritical >= attacker.CriticalChance)
                    {
                        criticalMultiplier = 2;
                    }
                }
            }
        }

        private static bool CalculateCanHitCritical(Card attacker)
        {
            return attacker.HitChance > 0 && attacker.CriticalChance > 0;
        }

        private static void CalculateAfterEffects(Card attacker, Card defender)
        {
            var afterAttackAttributesOfAttacker = attacker.Attributes.Where(x =>
                    x.AttributeVariables.Any(y => y.TriggerAttributeOn == AttributeTriggers.AfterAttack))
                .SelectMany(x => x.AttributeVariables);
            var afterDefenceAttributesOfDefender = attacker.Attributes.Where(x =>
                    x.AttributeVariables.Any(y => y.TriggerAttributeOn == AttributeTriggers.AfterDefence))
                .SelectMany(x => x.AttributeVariables);
            var cardType = typeof(Card);

            foreach (var attribute in afterAttackAttributesOfAttacker)
            {
                var propertyToAffect = cardType.GetProperty(attribute.CardPropertyToAffect)?.GetValue(attacker);
                var toAffect = (ushort)propertyToAffect;
                CalculateEffect(ref toAffect, attribute.ScaleType, attribute.Value);
                cardType.GetProperty(attribute.CardPropertyToAffect)?.SetValue(attacker, toAffect);
            }
            foreach (var attribute in afterDefenceAttributesOfDefender)
            {
                var propertyToAffect = cardType.GetProperty(attribute.CardPropertyToAffect)?.GetValue(defender);
                var toAffect = (ushort)propertyToAffect;
                CalculateEffect(ref toAffect, attribute.ScaleType, attribute.Value);
                cardType.GetProperty(attribute.CardPropertyToAffect)?.SetValue(defender, toAffect);
            }
        }

        private static void CalculateBeforeEffects(Card attacker, Card defender)
        {
            var beforeAttackAttributesOfAttacker = attacker.Attributes.Where(x =>
                    x.AttributeVariables.Any(y => y.TriggerAttributeOn == AttributeTriggers.BeforeAttack))
                .SelectMany(x => x.AttributeVariables);

            var beforeDefenceAttributesOfDefender = attacker.Attributes.Where(x =>
                    x.AttributeVariables.Any(y => y.TriggerAttributeOn == AttributeTriggers.BeforeDefence))
                .SelectMany(x => x.AttributeVariables);
            var cardType = typeof(Card);

            foreach (var attribute in beforeAttackAttributesOfAttacker)
            {
                var propertyToAffect = cardType.GetProperty(attribute.CardPropertyToAffect)?.GetValue(attacker);
                var toAffect = (ushort)propertyToAffect;
                CalculateEffect(ref toAffect, attribute.ScaleType, attribute.Value);
                cardType.GetProperty(attribute.CardPropertyToAffect)?.SetValue(attacker, toAffect);
            }

            foreach (var attribute in beforeDefenceAttributesOfDefender)
            {
                var propertyToAffect = cardType.GetProperty(attribute.CardPropertyToAffect)?.GetValue(defender);
                var toAffect = (ushort)propertyToAffect;
                CalculateEffect(ref toAffect, attribute.ScaleType, attribute.Value);
                cardType.GetProperty(attribute.CardPropertyToAffect)?.SetValue(defender, toAffect);
            }
        }

        private static void CalculateEffect(ref ushort propertyToAffect, ScaleType scaleType, byte value)
        {
            switch (scaleType)
            {
                case ScaleType.Ratio:
                    propertyToAffect += (ushort)(propertyToAffect * value / 100);
                    break;
                case ScaleType.Direct:
                    propertyToAffect += value;
                    break;
                case ScaleType.Multiply:
                    propertyToAffect *= value;
                    break;
                case ScaleType.Sets:
                    propertyToAffect = value;
                    break;
            }
        }
    }
}