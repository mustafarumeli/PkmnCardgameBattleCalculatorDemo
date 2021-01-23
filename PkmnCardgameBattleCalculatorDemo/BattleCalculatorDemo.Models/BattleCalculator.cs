using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCalculatorDemo.Models
{
    public static class BattleCalculator
    {
        private const double ATTACKDEFENCERATIOMULTIPLER = 50;

        public static void Attacks(this Card attacker, Card defender)
        {

            Card attackerCopy = attacker;
            Card defenderCopy = defender;
            CalculateEffects(attackerCopy, defenderCopy, AttributeTriggers.BeforeAttack);
            CalculateEffects(defenderCopy, attackerCopy, AttributeTriggers.BeforeDefence);

            DuringEffectInfo dei = CalculateDamage(attackerCopy, defenderCopy);
            defenderCopy.Hp -= dei.DamageDealt;

            CalculateEffects(attackerCopy, defenderCopy, AttributeTriggers.DuringAttack, dei);
            CalculateEffects(defenderCopy, attackerCopy, AttributeTriggers.DuringAttack, dei);

            CalculateEffects(attackerCopy, defenderCopy, AttributeTriggers.AfterAttack);

            if (defender.Hp > 0)
            {
                CalculateEffects(defenderCopy, attackerCopy, AttributeTriggers.AfterDefence);
            }

            RevertEffects(attackerCopy, defenderCopy, AttributeTriggers.BeforeAttack);
            RevertEffects(defenderCopy, attackerCopy, AttributeTriggers.BeforeDefence);
        }

        private static void RevertEffects(Card attacker, Card defender, AttributeTriggers trigger)
        {
            foreach (IRevertableValueVariable attackerAttribute in attacker.Attributes.Where(x => x.TriggerAttributeOn == trigger && x is IRevertableValueVariable))
            {
                IVariableParameter parameter = attackerAttribute switch
                {
                    IValueVariable<SelfCardParameter> => new SelfCardParameter(attacker),
                    IValueVariable<DoubleCardParameter> => new DoubleCardParameter(attacker, defender)
                };
                attackerAttribute.Revert(parameter);
            }
        }

        // Damage = IsCritical X Random(1,1.25) X Type Modifier X ((A.Attack / D.Defence) *50)
        private static DuringEffectInfo CalculateDamage(Card attacker, Card defender)
        {
            bool canHitCritical = CalculateCanHitCritical(attacker);
            short criticalMultiplier = 1;
            Random rnd = new Random();
            CalculateCriticalMultipler(attacker, canHitCritical, rnd, ref criticalMultiplier);
            double randomMultiplier = (rnd.Next(100, 125) / 100d);
            short typeMultiplier = GetTypeMultiplier(attacker, defender);
            double calculated = (attacker.Atk / (double)defender.Def * ATTACKDEFENCERATIOMULTIPLER);

            DuringEffectInfo dei = new DuringEffectInfo();
            dei.DamageDealt = (short)(criticalMultiplier * randomMultiplier * typeMultiplier * calculated);
            dei.WasCritical = criticalMultiplier == 2;
            return dei;
        }

        private static byte GetTypeMultiplier(Card attacker, Card defender)
        {
            return 1;
        }

        private static void CalculateCriticalMultipler(Card attacker, bool canHitCritical, Random rnd,
            ref short criticalMultiplier)
        {
            criticalMultiplier = 2;
            return;
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

        public static IEnumerable<IValueVariable> GetWhereEnumHas(this IEnumerable<IValueVariable> list,
            params AttributeTriggers[] attributeTriggers)
        {
            var mainEnum = attributeTriggers[0];
            for (var i = 1; i < attributeTriggers.Length; i++)
            {
                mainEnum |= attributeTriggers[i];
            }


            return list.Where(x => x.TriggerAttributeOn.HasFlag(mainEnum));
        }

        private static bool CalculateCanHitCritical(Card attacker)
        {
            return attacker.HitChance > 0 && attacker.CriticalChance > 0;
        }
        private static void CalculateEffects(Card attacker, Card defender, AttributeTriggers trigger, DuringEffectInfo dei = null)
        {
            foreach (IValueVariable attackerAttribute in attacker.Attributes.Where(x => x.TriggerAttributeOn == trigger))
            {
                IVariableParameter parameter = attackerAttribute switch
                {
                    IValueVariable<SelfCardParameter> => new SelfCardParameter(attacker),
                    IValueVariable<DoubleCardParameter> => new DoubleCardParameter(attacker, defender),
                    IValueVariable<DuringCardParameter> => new DuringCardParameter(attacker, dei),
                };
                attackerAttribute.Affect(parameter);
            }
        }
    }
}