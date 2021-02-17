namespace BattleCalculatorDemo.Models.Evolve
{
    public interface IEvolvable
    {
        IMonsterCard Evolve();
    }
    public interface IDevolvable
    {
        IMonsterCard Devolve();
    }

    public interface IDevolve<out TPrevious> : IDevolvable where TPrevious : IMonsterCard
    {
        TPrevious Devolve();
        IMonsterCard IDevolvable.Devolve()
        {
            return Devolve();
        }
    }

    public interface IEvolve<out TNext> : IEvolvable where TNext : IMonsterCard
    {
        TNext Evolve();
        IMonsterCard IEvolvable.Evolve()
        {
            return Evolve();
        }
    }
}