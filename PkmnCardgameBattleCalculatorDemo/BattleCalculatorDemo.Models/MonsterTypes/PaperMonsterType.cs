using System.Collections;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    class PaperMonsterType : IMonsterType
    {
        public string Name { get; } = "Rock";
        public string Icon { get; } = "rock.png";
        public ArrayList TypeAgainst { get; }


        public PaperMonsterType()
        {
            TypeAgainst.Add(new MonsterTypeMultiplier<RockMonsterType>(2.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<PaperMonsterType>(1.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<ScissorsMonsterType>(0.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<GlassMonsterType>(2.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<SoundMonsterType>(1.5d));
        }
    }
}