using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class CowardCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => " Coward";
        public override string Description => $"If no ally left in the field, returns to your hand";
    }
}