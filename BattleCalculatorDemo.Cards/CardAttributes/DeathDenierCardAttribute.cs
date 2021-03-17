using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class DeathDenierCardAttribute : OutsideCombatCardAttribute
    {
        public override string Name => "Death Denier";
        public override string Description => $"After takes critical damage. Devolves";
    }
}