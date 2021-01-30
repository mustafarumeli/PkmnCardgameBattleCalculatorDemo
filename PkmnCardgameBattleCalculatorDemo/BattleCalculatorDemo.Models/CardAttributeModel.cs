using System;

namespace BattleCalculatorDemo.Models
{
    public record CardAttributeModel(string Name, int VariableCount, Type type);
    public record CardAttributeModelWithoutType(string Name, int VariableCount);
}