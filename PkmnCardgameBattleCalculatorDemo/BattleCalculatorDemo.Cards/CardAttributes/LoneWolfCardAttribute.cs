using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class LoneWolfCardAttribute : OutsideCombatCardAttribute
    {
        private string desc;

        public LoneWolfCardAttribute(string desc)
        {
            this.desc = desc;
        }

        public override string Name => "Lone Wolf";
        public override string Description => "Whenever this is your only ally in the field do something";
        public override string GetCardSpecificDescription()
        {
            return Name + ": " + desc;
        }
    }
}