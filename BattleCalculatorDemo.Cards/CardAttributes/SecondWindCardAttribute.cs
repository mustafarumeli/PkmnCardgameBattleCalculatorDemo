using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class SecondWindCardAttribute : OutsideCombatCardAttribute
    {
        public SecondWindCardAttribute(int healthThreshold, string desc)
        {
            _healthThreshold = healthThreshold;
            _desc = desc;
        }
        
        private readonly int _healthThreshold;
        private readonly string _desc;
        public override string Name => "Sociopath";
        public override string Description => $"Does something when its health lower or equal to {_healthThreshold}";
        public override string GetCardSpecificDescription()
        {
            return Name + " " + _healthThreshold + ": " + _desc;
        }
    }
}