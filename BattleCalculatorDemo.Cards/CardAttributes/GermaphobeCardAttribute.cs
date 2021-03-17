using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class GermaphobeCardAttribute : OutsideCombatCardAttribute
    {
        public GermaphobeCardAttribute(int turnCount)
        {
            _turnCount = turnCount;
        }

        private readonly int _turnCount;
        public override string Name => "Germaphobe";
        public override string Description => $"Takes {_turnCount} times more damage from items";
        public override string GetCardSpecificDescription()
        {
            return Name + " " + _turnCount;
        }
    }
}