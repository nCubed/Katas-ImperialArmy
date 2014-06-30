using System;
using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Common.Soldier;
using ImperialArmy.Common.SoldierOrder;
using ImperialArmy.Military.Soldier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TypeAsserter;

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
        public void FlyingRainOfFire_Is_Internal_Sealed_NotAbstract()
        {
            AssertClass<FlyingRainOfFire>.IsInternal();
            AssertClass<FlyingRainOfFire>.IsSealed();
            AssertClass<FlyingRainOfFire>.IsNotAbstract();
        }

        [TestMethod]
        public void FlyingRainOfFire_Inherits_FootSolider()
        {
            AssertClass<FlyingRainOfFire>.InheritsBaseClass<FootSoldier>();
            AssertClass<FlyingRainOfFire>.InheritsAbstractBaseClass<SoldierBase>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_ISoldier()
        {
            AssertClass<FlyingRainOfFire>.ImplementsInterface<ISoldier>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_IArcher()
        {
            AssertClass<FlyingRainOfFire>.ImplementsInterface<IArcher>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_IHorseman()
        {
            AssertClass<FlyingRainOfFire>.ImplementsInterface<IHorseman>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_IFlyingRainOfFire()
        {
            AssertClass<FlyingRainOfFire>.ImplementsInterface<IFlyingRainOfFire>();
        }

        [TestMethod]
        public void FlyingRainOfFire_Implements_AllSoldierOrders()
        {
            AssertClass<FlyingRainOfFire>.ImplementsInterface<IFlyingRainOfFire>();
            AssertClass<FlyingRainOfFire>.ImplementsInterface<IShootDistantFoes>();
            AssertClass<FlyingRainOfFire>.ImplementsInterface<ITrampleFoes>();
            AssertClass<FlyingRainOfFire>.ImplementsInterface<ILeadTheCharge>();
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