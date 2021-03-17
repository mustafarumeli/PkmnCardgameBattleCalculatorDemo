using BattleCalculatorDemo.AbstractionLayer;
using MediatR;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class CowardCardAttribute : OutsideCombatCardAttribute, INotification
    {
        public override string Name => " Coward";
        public override string Description => $"If no ally left in the field, returns to your hand";
    }
}