using System;

namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface IMonsterTypeMultiplier
    {
        double Modifier { get; }
        Type OtherMonsterType { get; }
    }
}