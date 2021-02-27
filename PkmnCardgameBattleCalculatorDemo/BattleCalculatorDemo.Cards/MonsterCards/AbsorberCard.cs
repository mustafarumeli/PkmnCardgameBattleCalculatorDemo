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
    public class AbsorberCard : MonsterCard, IEvolve<MatteCard>, IDevolve<ReflektorCard>, INotificationHandler<CardEvolvedNotification>
    {
        public override string Name { get; set; } = "Absorber";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 75;
        public override int Atk { get; set; } = 0;
        public override int Def { get; set; } = 120;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public AbsorberCard()
        {
            Attributes.WithEarlyBird().WithShower("Can't Be targeted by monsters");
            Types.HasRock().HasGlass();
        }

        public MatteCard Evolve()
        {
            return new();
        }
        public ReflektorCard Devolve()
        {
            return new();
        }

        public Task Handle(CardEvolvedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}