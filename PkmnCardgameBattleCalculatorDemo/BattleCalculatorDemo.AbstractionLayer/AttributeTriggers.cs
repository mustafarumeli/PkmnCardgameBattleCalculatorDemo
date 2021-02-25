using System;

namespace BattleCalculatorDemo.AbstractionLayer
{
    [Flags]
    public enum AttributeTriggers
    {
        BeforeAttack = 1,
        BeforeDefense = 2,
        AfterAttack = 4,
        AfterDefense = 8,
        DuringAttack = 16
    }
}