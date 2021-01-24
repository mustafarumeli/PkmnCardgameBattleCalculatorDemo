using System.Collections;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    class ScissorsMonsterType : IMonsterType
    {
        public string Name { get; } = "Rock";
        public string Icon { get; } = "rock.png";
        public ArrayList TypeAgainst { get; }


        public ScissorsMonsterType()
        {
            TypeAgainst.Add(new MonsterTypeMultiplier<RockMonsterType>(0.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<PaperMonsterType>(2.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<ScissorsMonsterType>(1.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<GlassMonsterType>(0.5d));
            TypeAgainst.Add(new MonsterTypeMultiplier<SoundMonsterType>(1.0d));

        }
    }
}