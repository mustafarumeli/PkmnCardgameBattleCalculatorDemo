using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class SecondWindCardAttribute : OutsideCombatCardAttribute
    {
        public SecondWindCardAttribute(int healthThreshold)
        {
            _healthThreshold = healthThreshold;
        }

        private readonly int _healthThreshold;
        public override string Name => "Sociopath";
        public override string Description => $"Does something when its health lower or equal to {_healthThreshold}";
    }
}