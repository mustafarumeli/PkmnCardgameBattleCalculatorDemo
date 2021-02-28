using System.Collections.Generic;
using System.Linq;
using MongoORM4NetCore;

namespace BattleCalculatorDemo.Models
{
    public class MonsterCardModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public string Description { get; set; }
        public string CardImage { get; set; }
        public string Artwork { get; set; }
        public string MainCardType { get; set; }
        public string SecondaryCardType { get; set; }

        public MonsterCardModel()
        {

        }

        public MonsterCardModel MapImages(List<CardImageEntity> crud)
        {
            var cardImageEntity = crud.FirstOrDefault(x => x.CardId == Id);
            if (cardImageEntity != null)
            {
                CardImage = cardImageEntity.CardImage;
                Artwork = cardImageEntity.Artwork;
            }

            return this;
        }
    }
}