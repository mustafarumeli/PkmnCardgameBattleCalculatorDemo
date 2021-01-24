using System.Collections;
using System.Collections.Generic;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    public class SoundMonsterType : IMonsterType
    {
        public string Name { get; } = "Sound";
        public string Icon { get; } = "rock.png";
        public IList<MonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<MonsterTypeMultiplier>();


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