using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Cards.MonsterType
{
    public class SoundMonsterType : DbObject, IMonsterType
    {
        public string Name { get; } = "Sound";
        public string Icon { get; } = "rock.png";
        public IList<IMonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<IMonsterTypeMultiplier>();


        public SoundMonsterType()
        {
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<RockMonsterType>(1.5d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<PaperMonsterType>(0.5d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<ScissorsMonsterType>(1.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<GlassMonsterType>(2.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<SoundMonsterType>(1.0d));
        }
    }
}