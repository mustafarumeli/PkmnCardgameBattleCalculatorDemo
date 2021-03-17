using System;
using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
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
        ICardAttributeAffectVariable GetSmaller(ICardAttributeAffectVariable other);
        ICardAttributeAffectVariable GetBigger(ICardAttributeAffectVariable other);
    }
}