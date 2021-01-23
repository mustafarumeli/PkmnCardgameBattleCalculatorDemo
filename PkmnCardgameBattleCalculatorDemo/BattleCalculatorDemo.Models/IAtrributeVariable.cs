using System.Collections.Generic;

namespace BattleCalculatorDemo.Models
{
    public interface IAtrributeVariable
    {
        public AttributeTriggers TriggerAttributeOn { get; }
    }
    public interface IOneSidedAttributeVariable : IAtrributeVariable
    {
        void Affects(ICard attacker);
    }

    public interface ITwoSidedAttributeVariable : IAtrributeVariable
    {
        void Affects(ICard attacker, ICard defender);
    }


    public interface IVariableValueWithScaling
    {
        public byte Value { get; set; }
        public ScaleType ScaleType { get; set; }
    }

    public class VariableValueWithScaling : IVariableValueWithScaling
    {
        public byte Value { get; set; }
        public ScaleType ScaleType { get; set; }
    }


    /*
      CallUp: Deal 2 damage to an enemy unit
               Deal 4 damage to an enemy unit
     */
    public class HardShellAttribute : IOneSidedAttributeVariable
    {
        private ushort _value;

        public HardShellAttribute(ushort value)
        {
            _value = value;
        }

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.AfterDefence;

        public void Affects(ICard card)
        {
            card.Hp += (ushort)(card.Hp * _value / 100);
        }

        
    }
}