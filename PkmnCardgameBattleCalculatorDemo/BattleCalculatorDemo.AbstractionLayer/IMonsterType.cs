using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface IMonsterType
    {
        string Name { get; }
        string Icon { get; }
        IList<IMonsterTypeMultiplier> MultiplierAgainstTypes { get; }

        double GetMultiplierAgainstType<T>() where T : IMonsterType
        {
            var againstType = typeof(T);
            return MultiplierAgainstTypes.FirstOrDefault(x =>
                x.OtherMonsterType == againstType).Modifier;
        }

        double GetMultiplierAgainstType(Type t)
        {
            if (!t.IsAssignableTo(typeof(IMonsterType)))
            {
                throw new InvalidOleVariantTypeException();
            }
            return MultiplierAgainstTypes.FirstOrDefault(x =>
                x.OtherMonsterType == t).Modifier;
        }
    }
}