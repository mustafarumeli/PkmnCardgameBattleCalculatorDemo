using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class LazyCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Lazy";
        public override string Description => "Instantly attacks while being attacked. Can't Attack";
    }
}