using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class ShowerCardAttribute : OutsideCombatCardAttribute
    {
        public ShowerCardAttribute(string desc)
        {
            _desc = desc;
        }
        private readonly string _desc;
        public override string Name => "Shower";
        public override string Description => "Does something when played, or Evolved";
        public override string GetCardSpecificDescription()
        {
            return Name + ": " + _desc;
        }
    }
}