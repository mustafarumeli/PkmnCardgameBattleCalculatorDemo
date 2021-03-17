using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;
using BattleCalculatorDemo.CQ.Notifications;
using MediatR;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class DwayCard : MonsterCard, IDevolve<FeMaleCard>, IEvolve<JohnsCard>, INotificationHandler<TurnPassedNotification>
    {
        public override string Name { get; set; } = "Dway";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 150;
        public override int Atk { get; set; } = 30;
        public override int Def { get; set; } = 190;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public DwayCard()
        {
            Attributes.WithLazy().WithCoward();
            Types.HasRock();
        }

        public JohnsCard Evolve()
        {
            return new();
        }
        public FeMaleCard Devolve()
        {
            return new();
        }

        Task INotificationHandler<TurnPassedNotification>.Handle(TurnPassedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}