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
    public class BhansCard : MonsterCard, IDevolve<JackCard>, INotificationHandler<TurnPassedNotification>
    {
        public override string Name { get; set; } = "Bhans";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 400;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public BhansCard()
        {
            Attributes.WithLoneWolf("Gain Bold");
            Types.HasScissors();
        }

        public JackCard Devolve()
        {
            return new();
        }

        public Task Handle(TurnPassedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}