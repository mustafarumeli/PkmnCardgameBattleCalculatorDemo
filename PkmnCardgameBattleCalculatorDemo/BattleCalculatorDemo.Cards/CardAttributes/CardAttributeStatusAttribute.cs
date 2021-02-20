using System;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class CardAttributeStatusAttribute : Attribute
    {
        public CardAttributeStatusAttribute(bool isBeta, int variableCount, string name)
        {
        }
    }
}