using System.Linq;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Models.Helpers;

namespace BattleCalculatorDemo.Models
{
    public class AttributesModel
    {
        public string AttributeName { get; set; }
        public int[] AttributeValues { get; set; }

        public ICardAttributeAffectVariable GetAsAttribute()
        {
            if (AttributeValues.Length == 0)
            {
                return CardAttributeHelper.GetCardAttributeTypeByName(AttributeName);
            }
            return CardAttributeHelper.GetCardAttributeTypeByNameDirect(AttributeName, AttributeValues.Select(x => (object)x).ToArray());
        }
    }
}
