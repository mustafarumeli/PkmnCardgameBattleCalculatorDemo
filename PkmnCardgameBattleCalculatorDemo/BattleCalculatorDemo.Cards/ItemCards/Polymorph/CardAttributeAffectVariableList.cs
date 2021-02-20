using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.Cards.CardAttributes;

namespace BattleCalculatorDemo.Cards.ItemCards.Polymorph
{
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
        public void Add<T>(T val) where T : ICardAttributeAffectVariable
        {
            var type = val.GetType();
            if (!_dictionary.TryGetValue(type, out var cardAttribute))
            {
                _dictionary.Add(type, val);
            }
            else
            {
                var biggerCardAttribute = (cardAttribute as IAttributeComparer)?.GetBigger(val);
                if (biggerCardAttribute == null) return;
                _dictionary.Remove(type);
                _dictionary.Add(type, biggerCardAttribute);
            }
        }
        public void AddRange<T>(IEnumerable<T> vals) where T : ICardAttributeAffectVariable
        {
            foreach (var affectVariable in vals)
            {
                Add(affectVariable);
            }
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
}
