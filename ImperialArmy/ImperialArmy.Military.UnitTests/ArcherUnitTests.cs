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
    public class ArcherUnitTests
    {
        private Mock<IBowAndArrow> _mockBow;
        private Archer _archer;

        [TestInitialize]
        public void Init()
        {
            _mockBow = new Mock<IBowAndArrow>();

            _archer = new Archer( _mockBow.Object );
        }

        [TestMethod]
        public void Archer_Inherits_FootSoldier()
        {
            AssertThat.ClassIsImplemented<Archer, FootSoldier>();
        }

        [TestMethod]
        public void Archer_Implements_ISoldier()
        {
            AssertThat.InterfaceIsImplemented<Archer, ISoldier>();
        }

        [TestMethod]
        public void Archer_Implements_IArcher()
        {
            AssertThat.InterfaceIsImplemented<Archer, IArcher>();
        }

        [TestMethod]
        public void Archer_Implements_IShootDistantFoes()
        {
            AssertThat.InterfaceIsImplemented<Archer, IShootDistantFoes>();
        }

        [TestMethod]
        public void Rank_Returns_Archer()
        {
            Assert.AreEqual( Rank.Archer, _archer.Rank );
        }

        [TestMethod]
        public void ShootDistantFoe_Shoots_OneArrow()
        {
            _archer.ShootDistantFoe();

            _mockBow.Verify( x => x.ShootArrow(), Times.Once );
        }

        [TestMethod]
        public void RemaininArrows_Returns_ArrowCount()
        {
            const int arrowCount = 7;

            _mockBow.Setup( x => x.ArrowCount ).Returns( arrowCount );

            int arrows = _archer.RemainingArrows;

            Assert.AreEqual( arrowCount, arrows );

            _mockBow.Verify( x => x.ArrowCount, Times.Once );
        }
    }
}