using System;

namespace BattleCalculatorDemo.AbstractionLayer
{
    [Flags]
    public enum AttributeTriggers
    {
        OutsideCombat = 1 << 0,
        BeforeAttack =  1 << 1,
        BeforeDefense = 1 << 2,
        AfterAttack =   1 << 3,
        AfterDefense =  1 << 4,
        DuringAttack =  1 << 5
    }
}