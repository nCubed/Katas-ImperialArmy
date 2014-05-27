using System;
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
    public class FlyingRainOfFireUnitTests
    {
        private FlyingRainOfFire _flyingRainOfFire;
        private Mock<IBowAndArrow> _mockBow;
        private Mock<IHorse> _mockHorse;
        private const string HorseName = "Bubba";

        [TestInitialize]
        public void Init()
        {
            _mockBow = new Mock<IBowAndArrow>();
            _mockHorse = new Mock<IHorse>();
            _mockHorse.Setup( x => x.Name ).Returns( HorseName );

            _flyingRainOfFire = new FlyingRainOfFire( _mockBow.Object, _mockHorse.Object );
        }

        [TestMethod]
        public void FlyingRainOfFire_Inherits_FootSolider()
        {
            AssertThat.ClassIsImplemented<FlyingRainOfFire, FootSoldier>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_ISoldier()
        {
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, ISoldier>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_IArcher()
        {
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, IArcher>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_IHorseman()
        {
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, IHorseman>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_IFlyingRainOfFire()
        {
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, IFlyingRainOfFire>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_AllSoldierOrders()
        {
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, IFightToTheDeath>();
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, IShootDistantFoes>();
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, ITrampleFoes>();
            AssertThat.InterfaceIsImplemented<FlyingRainOfFire, ILeadTheCharge>();
        }

        [TestMethod]
        public void Rank_Returns_FlyingRainOfFire()
        {
            Assert.AreEqual( Rank.FlyingRainOfFire, _flyingRainOfFire.Rank );
        }

        [TestMethod]
        public void ShootDistantFoe_Shoots_OneArrow()
        {
            _flyingRainOfFire.ShootDistantFoe();

            _mockBow.Verify( x => x.ShootArrow(), Times.Once );
        }

        [TestMethod]
        public void RemaininArrows_Returns_ArrowCount()
        {
            const int arrowCount = 7;

            _mockBow.Setup( x => x.ArrowCount ).Returns( arrowCount );

            int arrows = _flyingRainOfFire.RemainingArrows;

            Assert.AreEqual( arrowCount, arrows );

            _mockBow.Verify( x => x.ArrowCount, Times.Once );
        }

        [TestMethod]
        public void HorseName_Returns_NameOfHorse()
        {
            Assert.AreEqual( HorseName, _flyingRainOfFire.HorseName );

            _mockHorse.Verify( x => x.Name, Times.Once );
        }

        [TestMethod]
        public void TrampleFoes_Tramples_WithHorse()
        {
            _flyingRainOfFire.TrampleFoes();

            _mockHorse.Verify( x => x.Trample(), Times.Once );
        }

        [TestMethod]
        [ExpectedException( typeof( NotImplementedException ) )]
        public void LeadTheCharge_NotImplemented()
        {
            _flyingRainOfFire.LeadTheCharge();
        }
    }
}