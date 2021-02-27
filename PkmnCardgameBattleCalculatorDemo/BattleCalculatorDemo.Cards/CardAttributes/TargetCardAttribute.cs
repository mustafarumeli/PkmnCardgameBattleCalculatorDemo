using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class TargetCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Target";
        public override string Description => "When in field, enemy monster only able to attack this card";
    }
}