using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class CradleCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Cradle";
        public override string Description => "When another monster with Cradle Dies this attacks attacker";
    }
}