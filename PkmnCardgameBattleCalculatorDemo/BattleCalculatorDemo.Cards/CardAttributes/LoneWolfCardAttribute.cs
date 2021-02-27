using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class LoneWolfCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Lone Wolf";
        public override string Description => "Whenever this is your only ally in the field do something";
    }
}