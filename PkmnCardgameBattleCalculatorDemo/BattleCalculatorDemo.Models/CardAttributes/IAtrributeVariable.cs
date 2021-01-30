namespace BattleCalculatorDemo.Models.CardAttributes
{
    public interface IVariableParameter { }

    public record SelfCardParameter(MonsterCard Self) : IVariableParameter;
    public record DoubleCardParameter(MonsterCard Attacker, MonsterCard Defender) : IVariableParameter;
    public record DuringCardParameter(MonsterCard Self, CombatResult CombatResult) : IVariableParameter;
}