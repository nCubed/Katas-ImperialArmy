using ImperialArmy.Common.Soldier;
using ImperialArmy.Military.Soldier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeAsserter;

namespace ImperialArmy.Military.UnitTests
{
    [TestClass]
    public class SoldierBaseUnitTests
    {
        [TestMethod]
        public void SoldierBase_IsInternal_Abstract()
        {
            AssertClass<SoldierBase>.IsAbstract();
            AssertClass<SoldierBase>.IsInternal();
        }

        [TestMethod]
        public void SoldierBase_Implements_ISoldier()
        {
            AssertClass<SoldierBase>.ImplementsInterface<ISoldier>();
        }
    }
}
