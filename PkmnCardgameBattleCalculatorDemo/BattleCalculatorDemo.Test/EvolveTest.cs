using BattleCalculatorDemo.Models;
using BattleCalculatorDemo.Models.CardAttributes;
using NUnit.Framework;

namespace BattleCalculatorDemo.Test
{
    [TestFixture]
    public class EvolveTest
    {
        private EvolveItemCard _evolveItemCard;
        private DevolveItemCard _devolveItemCard;
        private MountainRangerCard _mountainRangerCard;
        private TheMountainCard _theMountainCard;
        [SetUp]
        public void SetUp()
        {
            _evolveItemCard = new();
            _devolveItemCard = new();
            _mountainRangerCard = new();
            _theMountainCard = new();
        }

        [Test]
        public void ShouldEvolve()
        {
            var evolveCardParameter = new EvolutionCardParameter()
            {
                Self = _mountainRangerCard
            };
            _evolveItemCard.Affect(evolveCardParameter);
            Assert.AreEqual(evolveCardParameter.ResultingMonsterCard.Name, "The Mountain");
        }
        [Test]
        public void ShouldDevolve()
        {
            var devolveCardParameter = new EvolutionCardParameter()
            {
                Self = _theMountainCard
            };
            _devolveItemCard.Affect(devolveCardParameter);
            Assert.AreEqual(devolveCardParameter.ResultingMonsterCard.Name, "Mountain Ranger");
        }
    }
}