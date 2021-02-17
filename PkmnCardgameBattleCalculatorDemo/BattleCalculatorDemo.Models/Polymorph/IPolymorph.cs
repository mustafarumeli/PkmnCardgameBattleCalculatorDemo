using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.MonsterTypes;

namespace BattleCalculatorDemo.Models.Polymorph
{
    public interface IPolymorpher
    {

        PolymorphedMonsterCard PolyMorph<TLeft, TRight>(TLeft leftCard, TRight rightCard)
                                                             where TLeft : IMonsterCard
                                                             where TRight : IMonsterCard;

    }
    public interface IPolymorphSides
    {
        public IMonsterCard LeftCard { get; set; }
        public IMonsterCard RightCard { get; set; }
    }
    public class PolymorphSides : IPolymorphSides
    {
        public PolymorphSides(IMonsterCard leftCard, IMonsterCard rightCard)
        {
            LeftCard = leftCard;
            RightCard = rightCard;
        }

        public PolymorphSides()
        {
            /// <summary>
            /// DO NOT DELETE !!
            /// </summary> 
        }
        public IMonsterCard LeftCard { get; set; }
        public IMonsterCard RightCard { get; set; }
    }
    public interface IPolymorphedMonsterCard
    {
        public IPolymorphSides PolymorphSides { get; set; }

    }
    public sealed class PolymorphedMonsterCard : IPolymorphedMonsterCard, IMonsterCard
    {

        private int _criticalChance = 50;
        private int _hitChance = 75;

        public string Name { get; set; }
        public string Image { get; set; }
        public int Hp { get; set; } = 0;
        public int Atk { get; set; } = 0;
        public int Def { get; set; } = 0;
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

        public IPolymorphSides PolymorphSides { get; set; } = new PolymorphSides();
    }

    public class Polymorpher : IPolymorpher
    {
        public PolymorphedMonsterCard PolyMorph<TLeft, TRight>(TLeft leftCard, TRight rightCard)
            where TLeft : IMonsterCard where TRight : IMonsterCard
        {
            return new()
            {
                Atk = leftCard.Atk + rightCard.Atk,
                Attributes = CombineAttributes(leftCard.Attributes, rightCard.Attributes),
                CriticalChance = Math.Max(leftCard.CriticalChance, rightCard.CriticalChance),
                Def = leftCard.Def + rightCard.Def,
                HitChance = Math.Max(leftCard.HitChance, rightCard.HitChance),
                Types = leftCard.Types.Union(rightCard.Types).ToList(),
                Name = string.Join("", leftCard.Name.Take(rightCard.Name.Length / 2)) +
                       string.Join("", rightCard.Name.TakeLast(rightCard.Name.Length / 2)),
                Hp = leftCard.Hp + rightCard.Hp,
                PolymorphSides = new PolymorphSides(leftCard, rightCard)
            };
        }

        List<ICardAttributeAffectVariable> CombineAttributes(
           IList<ICardAttributeAffectVariable> leftCardAttribute,
           IList<ICardAttributeAffectVariable> rightCardAttribute)
        {
            CardAttributeAffectVariableList list = new CardAttributeAffectVariableList();
            list.AddRange(leftCardAttribute);
            list.AddRange(rightCardAttribute);
            return list;
        }
    }

    public class CardAttributeAffectVariableList : IEnumerable<ICardAttributeAffectVariable>
    {
        private Dictionary<Type, ICardAttributeAffectVariable> _dictionary = new();
        public IEnumerator<ICardAttributeAffectVariable> GetEnumerator()
        {
            return _dictionary.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Add<T>(T val) where T : ICardAttributeAffectVariable
        {
            var type = val.GetType();
            if (!_dictionary.TryGetValue(type, out var cardAttribute))
            {
                _dictionary.Add(type, val);
            }
            else
            {
                var biggerCardAttribute = (cardAttribute as IAttributeComparer).GetBigger(val);
                _dictionary.Remove(type);
                _dictionary.Add(type, biggerCardAttribute);
            }

            return 0;
        }
        public void AddRange<T>(IEnumerable<T> vals) where T : ICardAttributeAffectVariable
        {
            vals.Select(Add).ToList();
        }

        public List<ICardAttributeAffectVariable> ToList()
        {
            return _dictionary.Values.ToList();
        }

        public static implicit operator List<ICardAttributeAffectVariable>(CardAttributeAffectVariableList list)
        {
            return list.ToList();
        }
    }
    public interface IDepolymorpher
    {
        IPolymorphSides Depolymorph(ref PolymorphedMonsterCard polymorphedMonsterCard);
    }
    public class Depolymorpher : IDepolymorpher
    {
        public IPolymorphSides Depolymorph(ref PolymorphedMonsterCard polymorphedMonsterCard)
        {
            var sides = polymorphedMonsterCard.PolymorphSides;
            polymorphedMonsterCard = null;
            return sides;
        }
    }
}
