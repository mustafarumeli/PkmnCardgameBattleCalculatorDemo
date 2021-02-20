namespace BattleCalculatorDemo.Cards
{
    public interface ICard
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; }

    }
}