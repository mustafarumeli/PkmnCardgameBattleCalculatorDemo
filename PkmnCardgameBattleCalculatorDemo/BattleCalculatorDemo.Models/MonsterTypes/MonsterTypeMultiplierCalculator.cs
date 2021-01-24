using System.Collections.Generic;
using System.Linq;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    public static class MonsterTypeMultiplierCalculator
    {
        public static double GetMultiplier(IMonsterCard attacker, IMonsterCard defender)
        {
            var elements = attacker.Types;
            double multiplier = 0;
            foreach (var element in elements)
            {
                var tempMultiplier = GetBasicMultiplier(element, defender.Types);
                if (tempMultiplier < 0.01)
                {
                    return 0;
                }

                multiplier += tempMultiplier;
            }

            return (double)(multiplier / elements.Count());
        }

        private static double GetBasicMultiplier(IMonsterType element, IList<IMonsterType> defenderTypes)
        {
            double retVal = 0.0d;
            foreach (var defenderType in defenderTypes)
            {
                retVal += element.GetMultiplierAgainstType(defenderType.GetType());
            }

            return retVal / defenderTypes.Count();
        }

    }
}