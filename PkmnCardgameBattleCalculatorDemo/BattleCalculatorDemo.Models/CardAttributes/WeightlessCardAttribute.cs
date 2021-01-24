using System;

namespace BattleCalculatorDemo.Models.CardAttributes
{
    public class WeightlessCardAttribute : ICardAttributeAffectVariable<DuringCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;
        readonly short _chance;
        readonly short _ratio;
        public string Name => $"Weightless {_chance} {_ratio}";

        public WeightlessCardAttribute(short chance, short ratio)
        {
            _chance = chance;
            _ratio = ratio;
        }

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            bool isFrigged = IsTriggered();
            if (isFrigged)
                parameter.Self.Hp += (short)(parameter.BattleResult.DamageDealt * 100 / _ratio);
        }

        private bool IsTriggered()
        {
            var rnd = new Random();
            var randVal = rnd.Next(0, 100);
            return _chance >= randVal;
        }
    }
}