namespace BattleCalculatorDemo.Cards.ItemCards.Polymorph
{
    public interface IDepolymorpher
    {
        IPolymorphSides Depolymorph(ref PolymorphedMonsterCard polymorphedMonsterCard);
    }
}