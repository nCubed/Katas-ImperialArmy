using System;
using ImperialArmy.Common;
using ImperialArmy.Common.Soldier;
using ImperialArmy.Common.SoldierOrder;
using ImperialArmy.Military.Soldier;
using ImperialArmy.Military.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void FootSoldier_Inherits_SoliderBase()
        {
            AssertThat.AbstractClassIsImplemented<FootSoldier, SoldierBase>();
        }

        [TestMethod]
        public void FootSoldier_Implements_ISoldier()
        {
            AssertThat.InterfaceIsImplemented<FootSoldier, ISoldier>();
        }

        [TestMethod]
        public void FootSoldier_Implements_IFootSoldier()
        {
            AssertThat.InterfaceIsImplemented<FootSoldier, IFootSoldier>();
        }

        [TestMethod]
        public void FootSoldier_Implements_IFightToTheDeath()
        {
            AssertThat.InterfaceIsImplemented<FootSoldier, IFightToTheDeath>();
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
