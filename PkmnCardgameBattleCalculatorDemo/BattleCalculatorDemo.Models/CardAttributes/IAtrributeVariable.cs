namespace BattleCalculatorDemo.Models.CardAttributes
{
    public interface IVariableParameter { }

    public record SelfCardParameter(Card Self) : IVariableParameter;
    public record DoubleCardParameter(Card Attacker, Card Defender) : IVariableParameter;
    public record DuringCardParameter(Card Self, BattleResult BattleResult) : IVariableParameter;
}