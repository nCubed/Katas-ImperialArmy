using System;
using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Military.Inventory;
using ImperialArmy.Military.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void Horse_Implements_IHorse()
        {
            AssertThat.InterfaceIsImplemented<Horse, IHorse>();
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