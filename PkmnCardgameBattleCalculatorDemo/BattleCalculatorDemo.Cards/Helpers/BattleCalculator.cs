using System;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;
using System.Linq;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.Helpers
{
    public static class BattleCalculator
    {
        private double AttackDefenseRatioMultiplier = 22.5;

        public static CombatResult Attacks(this MonsterCard attacker, MonsterCard defender,double attackDefenseRatioMultiplier = 22.5)
        {
            AttackDefenseRatioMultiplier = attackDefenseRatioMultiplier; // for test purposes
                
            CalculateBeforeCombatEffects(attacker, defender);
            CombatResult combatResult = CalculateInCombatEffects(attacker, defender);
            CalculateAfterCombatEffects(attacker, defender, combatResult);
            return combatResult;
        }

        #region private Methods
        private static void CalculateAfterCombatEffects(MonsterCard attacker, MonsterCard defender, CombatResult combatResult)
        {
            CalculateEffects(attacker, defender, AttributeTriggers.AfterAttack);

            if (defender.Hp <= 0)
            {
                combatResult.DidDefenderDie = true;
            }

            CalculateEffects(defender, attacker, AttributeTriggers.AfterDefense);
            RevertEffects(attacker, defender, AttributeTriggers.BeforeAttack);
            RevertEffects(defender, attacker, AttributeTriggers.BeforeDefense);
        }
        private static CombatResult CalculateInCombatEffects(MonsterCard attacker, MonsterCard defender)
        {
            CombatResult combatResult = CalculateDamage(attacker, defender);
            defender.Hp -= combatResult.DamageDealt;
            CalculateEffects(attacker, defender, AttributeTriggers.DuringAttack, combatResult);
            CalculateEffects(defender, attacker, AttributeTriggers.DuringAttack, combatResult);
            return combatResult;
        }
        private static void CalculateBeforeCombatEffects(MonsterCard attackerCopy, MonsterCard defenderCopy)
        {
            CalculateEffects(attackerCopy, defenderCopy, AttributeTriggers.BeforeAttack);
            CalculateEffects(defenderCopy, attackerCopy, AttributeTriggers.BeforeDefense);
        }
        private static void RevertEffects(MonsterCard attacker, MonsterCard defender, AttributeTriggers trigger)
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
        private static CombatResult CalculateDamage(MonsterCard attacker, MonsterCard defender)
        {
            bool canHitCritical = CalculateCanHitCritical(attacker);
            int criticalMultiplier = 1;
            Random rnd = new Random();
            CalculateCriticalMultiplier(attacker, canHitCritical, rnd, ref criticalMultiplier);
            double randomMultiplier = (rnd.Next(100, 125) / 100d);
            double typeMultiplier = GetTypeMultiplier(attacker, defender);
            double calculated = (attacker.Atk / (double)defender.Def * AttackDefenseRatioMultiplier);

            CombatResult dei = new CombatResult
            {
                DamageDealt = (int)(criticalMultiplier * randomMultiplier * typeMultiplier * calculated),
                WasCritical = criticalMultiplier == 2
            };
            return dei;
        }
        private static double GetTypeMultiplier(MonsterCard attacker, MonsterCard defender)
        {
            return MonsterTypeMultiplierCalculator.GetMultiplier(attacker, defender);
        }

        private static void CalculateCriticalMultiplier(MonsterCard attacker, bool canHitCritical, Random rnd,
            ref int criticalMultiplier)
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

        private static bool CalculateCanHitCritical(MonsterCard attacker)
        {
            return attacker.HitChance > 0 && attacker.CriticalChance > 0;
        }
        private static void CalculateEffects(MonsterCard attacker, MonsterCard defender, AttributeTriggers trigger, CombatResult dei = null)
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
