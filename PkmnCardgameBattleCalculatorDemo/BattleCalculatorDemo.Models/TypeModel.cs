using BattleCalculatorDemo.Cards.MonsterType;
using BattleCalculatorDemo.Models.Helpers;

namespace BattleCalculatorDemo.Models
{
    public class TypeModel
    {
        public string TypeName { get; set; }

        public IMonsterType GetAsMonsterType()
        {
            return CardTypeHelper.GetByName(TypeName);
        }
    }
}