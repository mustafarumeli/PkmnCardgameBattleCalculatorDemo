using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class BoldCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Bold";
        public override string Description => "When attacks it attacks all Monsters on Field ";
    }
}