using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.MonsterTypes;

namespace BattleCalculatorDemo.Models.Models
{
    public class CardReadModel
    {
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Types { get; set; }
    }
    public class CardModel
    {
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IEnumerable<AttributesModel> Attributes { get; set; }
        public IEnumerable<TypeModel> Types { get; set; }
    }

    public class TypeModel
    {
        public string TypeName { get; set; }

        public IMonsterType GetAsMonsterType()
        {
            return CardTypeHelper.GetByName(TypeName);
        }
    }
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
