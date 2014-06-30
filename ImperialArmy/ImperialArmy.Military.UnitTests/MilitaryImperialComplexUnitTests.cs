using System.Collections.Generic;
using ImperialArmy.Common.Soldier;
using ImperialArmy.Military.Soldier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeAsserter;

namespace ImperialArmy.Military.UnitTests
{
    [TestClass]
    public class MilitaryImperialComplexUnitTests
    {
        [TestMethod]
        public void CreateSoldier_Creates_IFootSoldier()
        {
            var soldier = MilitaryImperialComplex.CreateSoldier<IFootSoldier>();

            Assert.IsNotNull( soldier );
            Assert.IsTrue( soldier is SoldierBase );
            Assert.IsTrue( soldier is FootSoldier );
        }

        [TestMethod]
        public void MilitaryImperialComplex_IsPublic_Static()
        {
            AssertClass.IsStatic( typeof( MilitaryImperialComplex ), ClassVisibility.Public );
        }

        [TestMethod]
        public void CreateSoldier_Creates_IArcher()
        {
            var soldier = MilitaryImperialComplex.CreateSoldier<IArcher>();

            Assert.IsNotNull( soldier );
            Assert.IsTrue( soldier is SoldierBase );
            Assert.IsTrue( soldier is FootSoldier );
            Assert.IsTrue( soldier is Archer );
        }

        [TestMethod]
        public void CreateSoldier_Creates_IHorseman()
        {
            var soldier = MilitaryImperialComplex.CreateSoldier<IHorseman>();

            Assert.IsNotNull( soldier );
            Assert.IsTrue( soldier is SoldierBase );
            Assert.IsTrue( soldier is FootSoldier );
            Assert.IsTrue( soldier is Horseman );
        }

        [TestMethod]
        public void CreateSoldier_Creates_IFlyingRainOfFire()
        {
            var soldier = MilitaryImperialComplex.CreateSoldier<IFlyingRainOfFire>();

            Assert.IsNotNull( soldier );
            Assert.IsTrue( soldier is SoldierBase );
            Assert.IsTrue( soldier is FootSoldier );
            Assert.IsTrue( soldier is FlyingRainOfFire );
        }

        [TestMethod]
        public void CreateManySoldiers_Creates_IFootSoldier()
        {
            AssertCreateManySoldiers<IFootSoldier>();
        }

        [TestMethod]
        public void CreateManySoldiers_Creates_IArcher()
        {
            AssertCreateManySoldiers<IArcher>();
        }

        [TestMethod]
        public void CreateManySoldiers_Creates_IHorseman()
        {
            AssertCreateManySoldiers<IHorseman>();
        }

        [TestMethod]
        public void CreateManySoldiers_Creates_IFlyingRainOfFire()
        {
            AssertCreateManySoldiers<IFlyingRainOfFire>();
        }


        private void AssertCreateManySoldiers<TSoldier>() where TSoldier : ISoldier
        {
            const int numberOfSoldiers = 1000;

            var soldiers = (List<TSoldier>)MilitaryImperialComplex.CreateManySoldiers<TSoldier>( numberOfSoldiers );

            Assert.AreEqual( numberOfSoldiers, soldiers.Count );
        }
    }
}