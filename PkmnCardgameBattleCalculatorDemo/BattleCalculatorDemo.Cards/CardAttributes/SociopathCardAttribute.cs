using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class SociopathCardAttribute : OutsideCombatCardAttribute
    {
        public SociopathCardAttribute(int monsterCount, string desc)
        {
            _monsterCount = monsterCount;
            _desc = desc;
        }

        private readonly int _monsterCount;
        private readonly string _desc;
        public override string Name => "Sociopath";
        public override string Description => $"Does something when there are more than {_monsterCount} monsters on the board";
        public override string GetCardSpecificDescription()
        {
            return Name + " " + _monsterCount + ": " + _desc;
        }
    }
}