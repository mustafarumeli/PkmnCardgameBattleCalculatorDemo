using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class ThinkerCardAttribute : OutsideCombatCardAttribute
    {
        public ThinkerCardAttribute(int turnCount, string desc)
        {
            _turnCount = turnCount;
            _desc = desc;
        }

        private readonly int _turnCount;
        private readonly string _desc;
        public override string Name => "Thinker";
        public override string Description => $"After {_turnCount} turns does something";
        public override string GetCardSpecificDescription()
        {
            return Name + " " + _turnCount + ": " + _desc;
        }
    }
}