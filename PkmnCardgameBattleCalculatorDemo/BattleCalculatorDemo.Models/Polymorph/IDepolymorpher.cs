namespace BattleCalculatorDemo.Models.Polymorph
{
    public interface IDepolymorpher
    {
        IPolymorphSides Depolymorph(ref PolymorphedMonsterCard polymorphedMonsterCard);
    }
}