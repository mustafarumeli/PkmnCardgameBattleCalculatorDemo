namespace BattleCalculatorDemo.Models.Polymorph
{
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
}