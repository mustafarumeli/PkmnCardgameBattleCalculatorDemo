using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class DeterminedCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Determined";
        public override string Description => "can't evolve or devolve ";
    }
}