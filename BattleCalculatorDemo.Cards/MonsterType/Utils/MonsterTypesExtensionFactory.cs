using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.MonsterType.Utils
{
    public static class MonsterTypesExtensionFactory
    {
        private static readonly GlassMonsterType GlassMonsterType = new();
        private static readonly PaperMonsterType PaperMonsterType = new();
        private static readonly RockMonsterType RockMonsterType = new();
        private static readonly ScissorsMonsterType ScissorsMonsterType = new();
        private static readonly SoundMonsterType SoundMonsterType = new();
        public static IList<IMonsterType> HasGlass(this IList<IMonsterType> list)
        {
            list.Add(GlassMonsterType);
            return list;
        }
        public static IList<IMonsterType> HasPaper(this IList<IMonsterType> list)
        {
            list.Add(PaperMonsterType);
            return list;
        }
        public static IList<IMonsterType> HasRock(this IList<IMonsterType> list)
        {
            list.Add(RockMonsterType);
            return list;
        }
        public static IList<IMonsterType> HasScissors(this IList<IMonsterType> list)
        {
            list.Add(ScissorsMonsterType);
            return list;
        }
        public static IList<IMonsterType> HasSound(this IList<IMonsterType> list)
        {
            list.Add(SoundMonsterType);
            return list;
        }
    }
}
