using System.Collections;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    class SoundMonsterType : IMonsterType
    {
        public string Name { get; } = "Rock";
        public string Icon { get; } = "rock.png";
        public ArrayList TypeAgainst { get; }


        public SoundMonsterType()
        {
            TypeAgainst.Add(new MonsterTypeMultiplier<RockMonsterType>(1.5d));
            TypeAgainst.Add(new MonsterTypeMultiplier<PaperMonsterType>(0.5d));
            TypeAgainst.Add(new MonsterTypeMultiplier<ScissorsMonsterType>(1.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<GlassMonsterType>(2.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<SoundMonsterType>(1.0d));
        }
    }
}