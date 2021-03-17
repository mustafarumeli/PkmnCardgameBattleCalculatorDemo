using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class HypedCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Hyped";
        public override string Description => "When Deals critical damage, it may attack again";
    }
}