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
        public void Horseman_Is_Internal_Sealed_NotAbstract()
        {
            AssertClass<Horseman>.IsInternal();
            AssertClass<Horseman>.IsSealed();
            AssertClass<Horseman>.IsNotAbstract();
        }

        [TestMethod]
        public void Horseman_Inherits_FootSoldier()
        {
            AssertClass<Horseman>.InheritsBaseClass<FootSoldier>();
            AssertClass<Horseman>.InheritsAbstractBaseClass<SoldierBase>();
        }

        [TestMethod]
        public void Horseman_Implements_ISoldier()
        {
            AssertClass<Horseman>.ImplementsInterface<ISoldier>();
        }

        [TestMethod]
        public void Horseman_Implements_IHorseman()
        {
            AssertClass<Horseman>.ImplementsInterface<IHorseman>();
        }

        [TestMethod]
        public void Horseman_Implements_ITrampleFoes()
        {
            AssertClass<Horseman>.ImplementsInterface<ITrampleFoes>();
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