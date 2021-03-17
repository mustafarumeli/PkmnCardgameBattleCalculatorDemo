using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Cards.MonsterType
{
    public class ScissorsMonsterType : DbObject, IMonsterType
    {
        public string Name { get; } = "Scissors";
        public string Icon { get; } = "icons/scissors.png";
        public IList<IMonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<IMonsterTypeMultiplier>();


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