using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType;
using MediatR;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MountainRangerCardOnDrawHandler : IRequestHandler<CardDrawnNotification>
    {
        private readonly MountainRangerCard _mountainRangerCard;

        public MountainRangerCardOnDrawHandler(MountainRangerCard mountainRangerCard)
        {
            _mountainRangerCard = mountainRangerCard;
        }

        public Task<Unit> Handle(CardDrawnNotification request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    public class CardDrawnNotification : IRequest
    {
    }

    public class MountainRangerCard : MonsterCard, IEvolve<TheMountainCard>, IRequestHandler<CardDrawnNotification>
    {
        public override string Name { get; set; } = "Mountain Ranger";
        private MountainRangerCardOnDrawHandler _drawHandler;

        public MountainRangerCard()
        {
            _drawHandler = new MountainRangerCardOnDrawHandler(this);
        }
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

        public Task<Unit> Handle(CardDrawnNotification request, CancellationToken cancellationToken)
        {
            return _drawHandler.Handle(request, cancellationToken);
        }
    }
}