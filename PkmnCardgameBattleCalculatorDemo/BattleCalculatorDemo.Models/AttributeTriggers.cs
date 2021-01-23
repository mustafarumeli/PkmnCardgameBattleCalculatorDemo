using System;

namespace BattleCalculatorDemo.Models
{
    [Flags]
    public enum AttributeTriggers
    {
        BeforeAttack = 1,
        BeforeDefence = 2,
        AfterAttack = 4,
        AfterDefence = 8,
        DuringAttack = 16
    }
}