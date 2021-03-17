using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Models
{
    public class CardImageEntity : DbObject
    {
        public string CardId { get; set; }
        public string CardImage { get; set; }
        public string Artwork { get; set; }
    }
}