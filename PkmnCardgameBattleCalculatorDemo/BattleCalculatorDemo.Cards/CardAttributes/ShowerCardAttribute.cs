using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class ShowerCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Shower";
        public override string Description => "Does something when played";
    }
}