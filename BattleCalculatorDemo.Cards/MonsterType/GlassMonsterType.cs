﻿using MongoORM4NetCore.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.MonsterType
{
    public class GlassMonsterType : IMonsterType
    {
        public string Name { get; } = "Glass";
        public string Icon { get; } = "icons/glass.png";
        public IList<IMonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<IMonsterTypeMultiplier>();

        public GlassMonsterType()
        {
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<RockMonsterType>(0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<PaperMonsterType>(0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<ScissorsMonsterType>(0.5d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<GlassMonsterType>(1d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<SoundMonsterType>(0d));
        }
    }
}
