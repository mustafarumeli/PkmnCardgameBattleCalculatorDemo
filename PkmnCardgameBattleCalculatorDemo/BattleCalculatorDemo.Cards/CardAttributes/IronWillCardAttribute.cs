using MongoDB.Bson.Serialization.Attributes;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 0, name: "Iron Will")]
    public class IronWillCardAttribute : ICardAttributeAffectVariable<DuringCardParameter>, IAttributeComparer<IronWillCardAttribute>
    {
        [BsonElement]
        private string _name = "Iron Will";

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            if (parameter.CombatResult.WasCritical)
                parameter.Self.Hp += (int)(parameter.CombatResult.DamageDealt / 2);
        }

        public int CompareTo(IronWillCardAttribute other)
        {
            return 0;
        }
    }
}