using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class WillCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Will";
        public override string Description => "Does something when dies";
    }
}