using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType;
using BattleCalculatorDemo.CQ.Notifications;
using MediatR;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class Squamation : MonsterCard
    {
        public override string Name { get; set; } = "Squamation";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 75;

        public override IList<ICardAttribute> Attributes { get; set; } =
            new List<ICardAttribute>() {new ChamaCardAttribute()};
        public override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>() { new PaperMonsterType()};
    }
    public class MountainRangerCard : MonsterCard, IEvolve<TheMountainCard>, INotificationHandler<CardDrawnNotification>
    {
        public override string Name { get; set; } = "Mountain Ranger";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; }
        public override int Atk { get; set; }
        public override int Def { get; set; }

        public override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>()
        {
            new IronWillCardAttribute(),
            new HardShellCardAttribute(25)
        };

        public override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>()
        {
            new RockMonsterType(), new GlassMonsterType()
        };

        public TheMountainCard Evolve()
        {
            return new();
        }

        public Task Handle(CardDrawnNotification request, CancellationToken cancellationToken)
        {
            request.BoardManager.Write("Mahmut");
            return Task.CompletedTask;
        }
    }
}