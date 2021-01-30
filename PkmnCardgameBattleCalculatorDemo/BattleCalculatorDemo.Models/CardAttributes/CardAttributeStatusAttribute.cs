using System;

namespace BattleCalculatorDemo.Models.CardAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class CardAttributeStatusAttribute : Attribute
    {
        public CardAttributeStatusAttribute(bool isBeta, int variableCount, string name)
        {
        }
    }
}