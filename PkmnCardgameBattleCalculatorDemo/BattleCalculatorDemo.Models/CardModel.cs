using System.Collections.Generic;

namespace BattleCalculatorDemo.Models
{
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
}