using System.Collections.Generic;

namespace BattleCalculatorDemo.Models
{
    public interface IValueVariable 
    {
        AttributeTriggers TriggerAttributeOn { get; }
        void Affect(IVariableParameter parameter);
    }
    public interface IValueVariable<in T>: IValueVariable where T:IVariableParameter
    {
        void Affect(T parameter);

        void IValueVariable.Affect(IVariableParameter parameter)
        {
            Affect((T)parameter);
        }
            
    }

    /*
      CallUp: Deal 2 damage to an enemy unit
               Deal 4 damage to an enemy unit
     */
    public class HardShellAttribute : IValueVariable<SelfCardParameter>
    {
        private ushort _value;

        public HardShellAttribute(ushort value)
        {
            _value = value;
        }

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.AfterDefence;
        
        public void Affect(SelfCardParameter parameter)
        {
            parameter.Self.Hp += _value;
        }
    }
    
    public interface IVariableParameter{}

    public record SelfCardParameter(Card Self) : IVariableParameter;

    public record DoubleCardParameter(Card Attacker, Card Defender) : IVariableParameter;
}