using System;
using System.Collections;

namespace BattleCalculatorDemo.Models.MonsterTypes
{

    public class MonsterTypeMultiplier
    {

        public double Modifier { get; }

        public Type OtherMonsterType { get; }

        public MonsterTypeMultiplier(double modifier, Type type)
        {
            Modifier = modifier;
            OtherMonsterType = type;
        }
        public static MonsterTypeMultiplier CreateInstance<T>(double modifier) where T : IMonsterType
        {
            return new(modifier, typeof(T));
        }
    }
}