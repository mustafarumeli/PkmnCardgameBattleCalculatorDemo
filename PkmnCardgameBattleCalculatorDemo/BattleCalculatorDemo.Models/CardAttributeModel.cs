using System;

namespace BattleCalculatorDemo.Models
{
    public record CardAttributeModel(string Name, int VariableCount, Type Type);
    public record CardAttributeModelWithoutType(string Name, int VariableCount);

    public record CardTypeModel(string Name, Type Type);
    public record CardTypeModelWithoutType(string Name);

}