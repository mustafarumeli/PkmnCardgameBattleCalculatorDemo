using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class ShatteredCardAttribute : CardAttribute,
        ICardAttributeAffectVariable<DoubleCardParameter>,
        IAttributeComparer<ShatteredCardAttribute>
    {

        public int Ratio { get; }

        public ShatteredCardAttribute(int ratio)
        {
            Ratio = ratio;
        }

        public void Affect(DoubleCardParameter parameter)
        {
            if (parameter.Self.Hp <= 0)
            {
                parameter.Other.Hp -= parameter.Other.Atk * Ratio / 100;
            }
        }

        public int CompareTo(ShatteredCardAttribute? other)
        {
            return Ratio.CompareTo(other);
        }
    }
}