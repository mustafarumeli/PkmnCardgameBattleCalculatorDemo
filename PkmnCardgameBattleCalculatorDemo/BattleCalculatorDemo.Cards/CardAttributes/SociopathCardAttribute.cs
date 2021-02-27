using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class SociopathCardAttribute : OutsideCombatCardAttribute
    {
        public SociopathCardAttribute(int monsterCount)
        {
            _monsterCount = monsterCount;
        }

        private readonly int _monsterCount;
        public override string Name => "Sociopath";
        public override string Description => $"Does something when there are more than {_monsterCount} monsters on the board";
    }
}