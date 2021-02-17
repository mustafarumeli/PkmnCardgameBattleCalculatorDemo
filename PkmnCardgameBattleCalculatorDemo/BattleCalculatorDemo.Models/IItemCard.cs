using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.Evolve;

namespace BattleCalculatorDemo.Models
{
    public interface IItemCard : ICard
    {
        void Affect(IVariableParameter variableParameter);
    }

    public interface IItemCard<T>: IItemCard where T : IVariableParameter
    {
        void Affect(T variableParameter);

        void IItemCard.Affect(IVariableParameter variableParameter)
        {
            Affect((T) variableParameter);
        }
    }
    
    public class EvolveItemCard : IItemCard<EvolutionCardParameter>
    {
        public string Name { get; set; } = "Evolve";
        public string Image { get; set; } = "evolve.png";
        public string Description { get; } = "Very nice evolve";

        public void Affect(EvolutionCardParameter variableParameter)
        {
            if (variableParameter.Self is IEvolvable evolvable)
            {
                var evolved = evolvable.Evolve();
                variableParameter.ResultingMonsterCard = evolved;
            }
        }
    }
    
    public class DevolveItemCard : IItemCard<EvolutionCardParameter>
    {
        public string Name { get; set; } = "Evolve";
        public string Image { get; set; } = "evolve.png";
        public string Description { get; } = "Very nice evolve";

        public void Affect(EvolutionCardParameter variableParameter)
        {
            if (variableParameter.Self is IDevolvable devolvable)
            {
                var devolved = devolvable.Devolve();
                variableParameter.ResultingMonsterCard = devolved;
            }
        }
    }
}