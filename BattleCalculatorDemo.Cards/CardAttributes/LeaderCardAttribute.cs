using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class LeaderCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Leader";
        public override string Description => "When evolves, evolve random ally ";
    }
}