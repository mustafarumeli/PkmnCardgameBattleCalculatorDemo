using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards
{
    public class CardImages : ICardImages
    {
        public CardImages(string artwork, string cardImage)
        {
            Artwork = artwork;
            CardImage = cardImage;
        }

        public CardImages()
        {

        }
        public string CardImage { get; set; }
        public string Artwork { get; set; }

    }


}