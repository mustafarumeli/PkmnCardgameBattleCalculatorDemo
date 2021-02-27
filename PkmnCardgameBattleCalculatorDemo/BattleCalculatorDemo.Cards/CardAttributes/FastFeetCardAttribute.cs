using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class FastFeetCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Fast Feet";
        public override string Description => "Can Attack imminently";
    }
}