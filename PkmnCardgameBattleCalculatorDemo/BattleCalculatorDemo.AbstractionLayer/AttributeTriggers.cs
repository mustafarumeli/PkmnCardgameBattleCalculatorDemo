using System;

namespace BattleCalculatorDemo.AbstractionLayer
{
    [Flags]
    public enum AttributeTriggers
    {
        OutsideCombat = 0 << 1,
        BeforeAttack = 0 << 2,
        BeforeDefense = 0 << 3,
        AfterAttack = 0 << 4,
        AfterDefense = 0 << 5,
        DuringAttack = 0 << 6
    }
}