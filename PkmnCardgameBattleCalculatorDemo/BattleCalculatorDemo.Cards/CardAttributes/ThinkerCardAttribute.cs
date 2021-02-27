using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class ThinkerCardAttribute : OutsideCombatCardAttribute
    {
        public ThinkerCardAttribute(int turnCount)
        {
            _turnCount = turnCount;
        }

        private readonly int _turnCount;
        public override string Name => "Thinker";
        public override string Description => $"After {_turnCount} turns does something";
    }
}