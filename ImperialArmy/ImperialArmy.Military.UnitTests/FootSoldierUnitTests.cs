using System;
using ImperialArmy.Common;
using ImperialArmy.Common.Soldier;
using ImperialArmy.Common.SoldierOrder;
using ImperialArmy.Military.Soldier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeAsserter;

namespace ImperialArmy.Military.UnitTests
{
    [TestClass]
    public class FootSoldierUnitTests
    {
        private FootSoldier _footSoldier;

        [TestInitialize]
        public void Init()
        {
            _footSoldier = new FootSoldier();
        }

        [TestMethod]
        public void FootSoldier_Is_Internal_NotSealed_NotAbstract()
        {
            AssertClass<FootSoldier>.IsInternal();
            AssertClass<FootSoldier>.IsNotSealed();
            AssertClass<FootSoldier>.IsNotAbstract();
        }

        [TestMethod]
        public void FootSoldier_Inherits_SoliderBase()
        {
            AssertClass<FootSoldier>.InheritsAbstractBaseClass<SoldierBase>();
        }

        [TestMethod]
        public void FootSoldier_Implements_ISoldier()
        {
            AssertClass<FootSoldier>.ImplementsInterface<ISoldier>();
        }

        [TestMethod]
        public void FootSoldier_Implements_IFootSoldier()
        {
            AssertClass<FootSoldier>.ImplementsInterface<IFootSoldier>();
        }

        [TestMethod]
        public void FootSoldier_Implements_IFightToTheDeath()
        {
            AssertClass<FootSoldier>.ImplementsInterface<IFightToTheDeath>();
        }

        [TestMethod]
        public void Rank_Returns_Soldier()
        {
            Assert.AreEqual( Rank.Soldier, _footSoldier.Rank );
        }

        [TestMethod]
        [ExpectedException( typeof( NotImplementedException ) )]
        public void FightToTheDeath_NotImplemented()
        {
            _footSoldier.FightToTheDeath();
        }
    }
}
