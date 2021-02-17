using System;

namespace BattleCalculatorDemo.Models.CardAttributes
{

    public interface IAttributeComparer<in T> : IAttributeComparer, IComparable<T> where T : ICardAttributeAffectVariable
    {
        ICardAttributeAffectVariable GetBigger(T other)
        {
            int result = CompareTo(other);
            if (result < 1)
            {
                return other;
            }

            return (ICardAttributeAffectVariable)this;
        }
        ICardAttributeAffectVariable GetSmaller(T other)
        {
            int result = CompareTo(other);
            if (result > 0)
            {
                return other;
            }

            return (ICardAttributeAffectVariable)this;
        }

        ICardAttributeAffectVariable IAttributeComparer.GetBigger(ICardAttributeAffectVariable other)
        {
            return GetBigger((T)other);
        }

        ICardAttributeAffectVariable IAttributeComparer.GetSmaller(ICardAttributeAffectVariable other)
        {
            return GetSmaller((T)other);
        }

    }
    public interface IAttributeComparer
    {
        ICardAttributeAffectVariable GetBigger(ICardAttributeAffectVariable other);
        ICardAttributeAffectVariable GetSmaller(ICardAttributeAffectVariable other);
    }

    public interface IVariableParameter { }

    public record SelfCardParameter(MonsterCard Self) : IVariableParameter;
    public record DoubleCardParameter(MonsterCard Attacker, MonsterCard Defender) : IVariableParameter;
    public record DuringCardParameter(MonsterCard Self, CombatResult CombatResult) : IVariableParameter;
}