using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Cards.MonsterType
{
    public class RockMonsterType : DbObject, IMonsterType
    {
        public string Name { get; } = "Rock";
        public string Icon { get; } = "icons/rock.png";
        public IList<IMonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<IMonsterTypeMultiplier>();


        public RockMonsterType()
        {
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<RockMonsterType>(1.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<PaperMonsterType>(0.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<ScissorsMonsterType>(2.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<GlassMonsterType>(3.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<SoundMonsterType>(0.5d));
        }
    }
}