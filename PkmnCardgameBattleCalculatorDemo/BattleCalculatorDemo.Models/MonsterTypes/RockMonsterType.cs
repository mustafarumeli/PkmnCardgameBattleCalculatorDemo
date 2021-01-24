using System.Collections;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    class RockMonsterType : IMonsterType
    {
        public string Name { get; } = "Rock";
        public string Icon { get; } = "rock.png";
        public ArrayList TypeAgainst { get; }


        public RockMonsterType()
        {
            TypeAgainst.Add(new MonsterTypeMultiplier<RockMonsterType>(1.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<PaperMonsterType>(0.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<ScissorsMonsterType>(2.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<GlassMonsterType>(3.0d));
            TypeAgainst.Add(new MonsterTypeMultiplier<SoundMonsterType>(0.5d));
        }
    }
}