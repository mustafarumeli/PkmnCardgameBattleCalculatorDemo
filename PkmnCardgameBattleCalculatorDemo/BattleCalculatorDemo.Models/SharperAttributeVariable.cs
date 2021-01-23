using System;

namespace BattleCalculatorDemo.Models
{
    public class SharperAttributeVariable : IValueVariable<SelfCardParameter>, IRevertableValueVariable<SelfCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeAttack;
        short _previousValue { get; set; }

        public void Affect(SelfCardParameter parameter)
        {
            _previousValue = parameter.Self.HitChance;
            parameter.Self.HitChance = 100;
        }



        public void Revert(SelfCardParameter parameter)
        {
            parameter.Self.HitChance = _previousValue;
        }
    }

    //While Defending has X% chance to take X% less damage
    public class WeightlessAttributeVariable : IValueVariable<DuringCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;
        short _chance, _ratio;
        public WeightlessAttributeVariable(short chance, short ratio)
        {
            _chance = chance;
            _ratio = ratio;
        }

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            bool isFrigged = IsTriggered();
            if (isFrigged)
                parameter.Self.Hp += (short)(parameter.DuringEffectInfo.DamageDealt * 100 / _ratio);
        }

        private bool IsTriggered()
        {
            Random rnd = new Random();
            var randVal = rnd.Next(0, 100);
            return _chance >= randVal;
        }
    }

    public class IronWillAttributeVariable : IValueVariable<DuringCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            if (parameter.DuringEffectInfo.WasCritical)
                parameter.Self.Hp += (short)(parameter.DuringEffectInfo.DamageDealt / 2);
        }

    }


    public class IronWillAttributeVariable : IValueVariable<DuringCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            if (parameter.DuringEffectInfo.WasCritical)
                parameter.Self.Hp += (short)(parameter.DuringEffectInfo.DamageDealt / 2);
        }

    }

    public class DuringEffectInfo
    {
        public short DamageDealt { get; set; }
        public bool WasCritical { get; set; }
    }

}