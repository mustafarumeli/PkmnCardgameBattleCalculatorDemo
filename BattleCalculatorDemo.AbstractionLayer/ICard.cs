namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface ICard
    {
        public string Name { get; set; }
        public ICardImages CardImages { get; set; }
        public string Description { get; }

    }
}