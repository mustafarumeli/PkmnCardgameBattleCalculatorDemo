namespace BattleCalculatorDemo.Models.Polymorph
{
    public interface IPolymorphSides
    {
        public IMonsterCard LeftCard { get; set; }
        public IMonsterCard RightCard { get; set; }
    }
}