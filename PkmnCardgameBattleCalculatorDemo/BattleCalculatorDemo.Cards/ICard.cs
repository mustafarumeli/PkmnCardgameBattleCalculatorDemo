namespace BattleCalculatorDemo.Cards
{
    public interface ICard
    {
        public string Name { get; set; }
        public CardImages CardImages { get; set; }
        public string Description { get; }

    }
}