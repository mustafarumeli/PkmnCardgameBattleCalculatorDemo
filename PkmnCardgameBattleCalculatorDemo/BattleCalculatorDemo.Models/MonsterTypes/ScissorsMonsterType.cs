﻿using System.Collections;
using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    public class ScissorsMonsterType : DbObject, IMonsterType
    {
        public string Name { get; } = "Scissors";
        public string Icon { get; } = "rock.png";
        public IList<MonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<MonsterTypeMultiplier>();


        public ScissorsMonsterType()
        {
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<RockMonsterType>(0.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<PaperMonsterType>(2.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<ScissorsMonsterType>(1.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<GlassMonsterType>(0.5d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<SoundMonsterType>(1.0d));

        }
    }
}