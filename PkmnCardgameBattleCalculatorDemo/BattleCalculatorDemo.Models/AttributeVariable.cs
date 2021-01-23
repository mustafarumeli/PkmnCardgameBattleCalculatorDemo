using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BattleCalculatorDemo.Models
{
    public class AttributeVariable
    {

        private IEnumerable<string> _cardProperties = typeof(Card).GetProperties().Where(x => CustomAttributeExtensions.GetCustomAttributes((MemberInfo) x).Contains(new AffectableCardPropertyAttribute())).Select(x => x.Name);
        private string _cardPropertyToAffect;
        public string CardPropertyToAffect
        {
            get => _cardPropertyToAffect;
            set
            {
                if (_cardProperties.Contains(value))
                {
                    _cardPropertyToAffect = value;
                }
                else
                {
                    throw new Exception("Card Property Does Not Found");
                }
            }
        }

        public byte Value { get; set; }
        public AttributeTriggers TriggerAttributeOn { get; set; }
        public ScaleType ScaleType { get; set; }

        public override string ToString()
        {
            return string.Join(",", _cardProperties);
        }
    }
}