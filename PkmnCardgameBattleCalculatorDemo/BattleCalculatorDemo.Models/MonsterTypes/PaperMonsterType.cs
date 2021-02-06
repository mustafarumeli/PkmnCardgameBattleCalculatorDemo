using System.Collections;
using System.Collections.Generic;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    public class PaperMonsterType : DbObject, IMonsterType
    {
        public string Name { get; } = "Paper";
        public string Icon { get; } = "rock.png";
        public ArrayList TypeAgainst { get; } = new ArrayList();

        public IList<MonsterTypeMultiplier> MultiplierAgainstTypes { get; } = new List<MonsterTypeMultiplier>();

        public PaperMonsterType()
        {
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<RockMonsterType>(2.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<PaperMonsterType>(1.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<ScissorsMonsterType>(0.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<GlassMonsterType>(2.0d));
            MultiplierAgainstTypes.Add(MonsterTypeMultiplier.CreateInstance<SoundMonsterType>(1.5d));
        }
    }
}