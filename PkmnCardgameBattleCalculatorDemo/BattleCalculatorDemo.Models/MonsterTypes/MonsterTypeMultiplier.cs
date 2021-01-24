using System;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    public class MonsterTypeMultiplier<TAgainst> where TAgainst : IMonsterType
    {
        private double _modifier;

        public new Type GetType()
        {
            return typeof(TAgainst);
        }
        public MonsterTypeMultiplier(double modifier)
        {
            this._modifier = modifier;
        }

    }
}