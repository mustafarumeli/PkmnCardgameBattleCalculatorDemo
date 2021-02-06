using System;

namespace BattleCalculatorDemo.Models.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 2, name: "Weigthless")]
    public class WeightlessCardAttribute : ICardAttributeAffectVariable<DuringCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;
        public int _chance;
        public int _ratio;
        public string Name { get; set; }
        public WeightlessCardAttribute(int chance, int ratio)
        {
            _chance = chance;
            _ratio = ratio;
            Name = $"Weightless {_chance} {_ratio}";
        }

        public WeightlessCardAttribute()
        {
                
        }
        public void Affect(DuringCardParameter parameter)
        {
            bool isFrigged = IsTriggered();
            if (isFrigged)
                parameter.Self.Hp += (int)(parameter.CombatResult.DamageDealt * 100 / _ratio);
        }

        private bool IsTriggered()
        {
            var rnd = new Random();
            var randVal = rnd.Next(0, 100);
            return _chance >= randVal;
        }
    }
}