using System;
using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.Models.CardAttributes;

namespace BattleCalculatorDemo.Models
{
    public static class BattleCalculator
    {
        private const double AttackDefenseRatioMultiplier = 50;

        public static BattleResult Attacks(this Card attacker, Card defender)
        {
            CalculateBeforeCombatEffects(attacker, defender);
            BattleResult battleResult = CalculateInCombatEffects(attacker, defender);
            CalculateAfterCombatEffects(attacker, defender, battleResult);
            return battleResult;
        }

        #region private Methods

        private static void CalculateAfterCombatEffects(Card attacker, Card defender, BattleResult battleResult)
        {
            CalculateEffects(attacker, defender, AttributeTriggers.AfterAttack);

            if (defender.Hp > 0)
            {
                CalculateEffects(defender, attacker, AttributeTriggers.AfterDefense);
            }
            else
            {
                battleResult.DidDefenderDie = true;
            }

            RevertEffects(attacker, defender, AttributeTriggers.BeforeAttack);
            RevertEffects(defender, attacker, AttributeTriggers.BeforeDefense);
        }

        private static BattleResult CalculateInCombatEffects(Card attacker, Card defender)
        {
            BattleResult battleResult = CalculateDamage(attacker, defender);
            defender.Hp -= battleResult.DamageDealt;
            CalculateEffects(attacker, defender, AttributeTriggers.DuringAttack, battleResult);
            CalculateEffects(defender, attacker, AttributeTriggers.DuringAttack, battleResult);
            return battleResult;
        }

        private static void CalculateBeforeCombatEffects(Card attackerCopy, Card defenderCopy)
        {
            CalculateEffects(attackerCopy, defenderCopy, AttributeTriggers.BeforeAttack);
            CalculateEffects(defenderCopy, attackerCopy, AttributeTriggers.BeforeDefense);
        }

        private static void RevertEffects(Card attacker, Card defender, AttributeTriggers trigger)
        {
            foreach (ICardAttributeRevertableVariable attackerAttribute in attacker.Attributes.Where(x => x.TriggerAttributeOn == trigger && x is ICardAttributeRevertableVariable))
            {
                IVariableParameter parameter = attackerAttribute switch
                {
                    ICardAttributeAffectVariable<SelfCardParameter> => new SelfCardParameter(attacker),
                    ICardAttributeAffectVariable<DoubleCardParameter> => new DoubleCardParameter(attacker, defender)
                };
                attackerAttribute.Revert(parameter);
            }
        }

        private static BattleResult CalculateDamage(Card attacker, Card defender)
        {
            bool canHitCritical = CalculateCanHitCritical(attacker);
            short criticalMultiplier = 1;
            Random rnd = new Random();
            CalculateCriticalMultiplier(attacker, canHitCritical, rnd, ref criticalMultiplier);
            double randomMultiplier = (rnd.Next(100, 125) / 100d);
            short typeMultiplier = GetTypeMultiplier(attacker, defender);
            double calculated = (attacker.Atk / (double)defender.Def * AttackDefenseRatioMultiplier);

            BattleResult dei = new BattleResult
            {
                DamageDealt = (short)(criticalMultiplier * randomMultiplier * typeMultiplier * calculated),
                WasCritical = criticalMultiplier == 2
            };
            return dei;
        }

        private static byte GetTypeMultiplier(Card attacker, Card defender)
        {
            //todo
            return 1;
        }

        private static void CalculateCriticalMultiplier(Card attacker, bool canHitCritical, Random rnd,
            ref short criticalMultiplier)
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
        private static void CalculateEffects(Card attacker, Card defender, AttributeTriggers trigger, BattleResult dei = null)
        {
            foreach (ICardAttributeAffectVariable attackerAttribute in attacker.Attributes.Where(x => x.TriggerAttributeOn == trigger))
            {
                IVariableParameter parameter = attackerAttribute switch
                {
                    ICardAttributeAffectVariable<SelfCardParameter> => new SelfCardParameter(attacker),
                    ICardAttributeAffectVariable<DoubleCardParameter> => new DoubleCardParameter(attacker, defender),
                    ICardAttributeAffectVariable<DuringCardParameter> => new DuringCardParameter(attacker, dei),
                };
                attackerAttribute.Affect(parameter);
            }
        }

        #endregion

    }
}