using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using BattleCalculatorDemo.AbstractionLayer.Utils;

namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface IAttribute
    {
         string Name { get; set; }
    }
    public interface IMonsterType : IDeepCloneable
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