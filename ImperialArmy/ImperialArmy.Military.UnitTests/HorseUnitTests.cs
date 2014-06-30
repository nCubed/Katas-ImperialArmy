using System;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Military.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeAsserter;

namespace ImperialArmy.Military.UnitTests
{
    [TestClass]
    public class HorseUnitTests
    {
        private const string HorseName = "Bubba";
        private Horse _horse;

        [TestInitialize]
        public void Init()
        {
            _horse = new Horse { Name = HorseName };
        }

        [TestMethod]
        public void Horseman_Is_Internal_Sealed_NotAbstract()
        {
            AssertClass<Horse>.IsInternal();
            AssertClass<Horse>.IsSealed();
            AssertClass<Horse>.IsNotAbstract();
        }

        [TestMethod]
        public void Horse_Implements_IHorse()
        {
            AssertClass<Horse>.ImplementsInterface<IHorse>();
        }

        [TestMethod]
        public void Name_Returns_ConstructorParameterName()
        {
            Assert.AreEqual( HorseName, _horse.Name );
        }

        [TestMethod]
        [ExpectedException( typeof( NotImplementedException ) )]
        public void Trample_NotImplemented()
        {
            _horse.Trample();
        }
    }
}