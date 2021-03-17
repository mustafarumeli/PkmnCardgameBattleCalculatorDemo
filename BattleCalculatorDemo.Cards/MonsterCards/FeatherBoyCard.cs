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
    public class FeatherBoyCard : MonsterCard, IEvolve<AngryEagleCard>, IDevolve<SurpriseEggCard>, INotificationHandler<CardPlayedNotification>
    {
        public override string Name { get; set; } = "Feather Boy";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 100;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public FeatherBoyCard()
        {
            Attributes.WithShower("Evolve a random ally");
            Types.HasGlass();
        }

        public AngryEagleCard Evolve()
        {
            return new();
        }
        public SurpriseEggCard Devolve()
        {
            return new();
        }

        public Task Handle(CardPlayedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}