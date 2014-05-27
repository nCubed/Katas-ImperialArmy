using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Common.Soldier;
using ImperialArmy.Common.SoldierOrder;
using ImperialArmy.Military.Soldier;
using ImperialArmy.Military.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ImperialArmy.Military.UnitTests
{
    [TestClass]
    public class HorsemanUnitTests
    {
        private const string HorseName = "Bubba";
        private Mock<IHorse> _mockHorse;
        private Horseman _horseman;

        [TestInitialize]
        public void Init()
        {
            _mockHorse = new Mock<IHorse>();
            _mockHorse.Setup( x => x.Name ).Returns( HorseName );
            _horseman = new Horseman( _mockHorse.Object );
        }

        [TestMethod]
        public void Horseman_Inherits_FootSoldier()
        {
            AssertThat.ClassIsImplemented<Horseman, FootSoldier>();
        }

        [TestMethod]
        public void Horseman_Implements_ISoldier()
        {
            AssertThat.InterfaceIsImplemented<Horseman, ISoldier>();
        }

        [TestMethod]
        public void Horseman_Implements_IHorseman()
        {
            AssertThat.InterfaceIsImplemented<Horseman, IHorseman>();
        }

        [TestMethod]
        public void Horseman_Implements_ITrampleFoes()
        {
            AssertThat.InterfaceIsImplemented<Horseman, ITrampleFoes>();
        }

        [TestMethod]
        public void Rank_Returns_Horseman()
        {
            Assert.AreEqual( Rank.Horseman, _horseman.Rank );
        }

        [TestMethod]
        public void HorseName_Returns_NameOfHorse()
        {
            Assert.AreEqual( HorseName, _horseman.HorseName );

            _mockHorse.Verify( x => x.Name, Times.Once );
        }

        [TestMethod]
        public void TrampleFoes_Tramples_WithHorse()
        {
            _horseman.TrampleFoes();

            _mockHorse.Verify( x => x.Trample(), Times.Once );
        }
    }
}