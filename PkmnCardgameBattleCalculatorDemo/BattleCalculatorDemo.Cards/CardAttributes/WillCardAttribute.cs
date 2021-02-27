using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class WillCardAttribute : OutsideCombatCardAttribute
    {
        private readonly string _desc;

        public WillCardAttribute(string desc)
        {
            _desc = desc;
        }

        public override string Name => "Will";
        public override string Description => "Does something when dies";
        public override string GetCardSpecificDescription()
        {
            return Name + ": " + _desc;
        }
    }
}