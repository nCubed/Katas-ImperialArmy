using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Military.Inventory;
using ImperialArmy.Military.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImperialArmy.Military.UnitTests
{
    [TestClass]
    public class BowAndArrowUnitTests
    {
        private BowAndArrow _bow;

        [TestInitialize]
        public void Init()
        {
            _bow = new BowAndArrow();
        }

        [TestMethod]
        public void BowAndArrow_Implements_IBowAndArrow()
        {
            AssertThat.InterfaceIsImplemented<BowAndArrow, IBowAndArrow>();
        }

        [TestMethod]
        public void Arrows_StartsWith_100Arrows()
        {
            Assert.AreEqual( 100, _bow.ArrowCount );
        }

        [TestMethod]
        public void ShootArrow_ReducesArrowCount_ByOne()
        {
            int startingArrowCount = _bow.ArrowCount;

            _bow.ShootArrow();

            int endingArrowCount = startingArrowCount - 1;

            Assert.AreEqual( endingArrowCount, _bow.ArrowCount );
        }

        [TestMethod]
        public void ShootArrow_CanShoot_AllArrows()
        {
            while( _bow.ArrowCount > 0 )
            {
                _bow.ShootArrow();
            }

            Assert.AreEqual( 0, _bow.ArrowCount );
        }
    }
}