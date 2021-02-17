using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.Evolve;
using BattleCalculatorDemo.Models.MonsterTypes;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Models
{
    public class TheMountainCard : MonsterCard, IDevolve<MountainRangerCard>
    {
        public override string Name { get; set; } = "The Mountain";

        public MountainRangerCard Devolve()
        {
            return new ();
        }
    }

    public class MountainRangerCard : MonsterCard, IEvolve<TheMountainCard>
    {
        public override string Name { get; set; } = "Mountain Ranger";

        public TheMountainCard Evolve()
        {
            return new();
        }
    }
    public class MonsterCard : DbObjectSD, IMonsterCard
    {

        private int _criticalChance = 50;
        private int _hitChance = 75;
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual int Hp { get; set; } = 0;
        public virtual int Atk { get; set; } = 0;
        public virtual int Def { get; set; } = 0;
        public int CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value > 100 ? (int)100 : value;
        }
        public int HitChance
        {
            get => _hitChance;
            set => _hitChance = value > 100 ? (int)100 : value;
        }
        public IList<ICardAttributeAffectVariable> Attributes { get; set; } = new List<ICardAttributeAffectVariable>();
        public IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();
        public string Description { get; set; }
        public string CardDescription => !string.IsNullOrWhiteSpace(Description) ? Description : string.Join(",", CreateCardDescription());

        private IEnumerable<string> CreateCardDescription()
        {
            return Attributes.Select(cardAttribute => cardAttribute.Name);
        }
        public void AddTypes(params IMonsterType[] monsterTypes)
        {
            Types = monsterTypes;
        }

        public string GetTypeNames()
        {
            return string.Join(",", Types.Select(x => x.Name));
        }

    }
}