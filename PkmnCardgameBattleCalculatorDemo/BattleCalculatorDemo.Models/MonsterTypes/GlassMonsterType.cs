using System.Collections;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    class GlassMonsterType : IMonsterType
    {
        public string Name { get; } = "Glass";
        public string Icon { get; } = "glass.png";
        public ArrayList TypeAgainst { get; }

        public GlassMonsterType()
        {
            TypeAgainst.Add(new MonsterTypeMultiplier<RockMonsterType>(0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<PaperMonsterType>(0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<ScissorsMonsterType>(0.5d));
            TypeAgainst.Add(new MonsterTypeMultiplier<GlassMonsterType>(1d));
            TypeAgainst.Add(new MonsterTypeMultiplier<SoundMonsterType>(0d));

        }
    }
}