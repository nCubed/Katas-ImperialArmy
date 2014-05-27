using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImperialArmy.Military.UnitTests.Helpers
{
    internal static class AssertThat
    {
        public static void ClassIsImplemented<TClass, TBaseClass>()
            where TClass : class
            where TBaseClass : class
        {
            Type baseType = typeof( TBaseClass );

            AssertIsAssignableFrom<TClass>( baseType );
        }

        public static void AbstractClassIsImplemented<TClass, TAbstractClass>()
            where TClass : class
            where TAbstractClass : class
        {
            Type abstractType = typeof( TAbstractClass );
            Assert.IsTrue( abstractType.IsAbstract );

            AssertIsAssignableFrom<TClass>( abstractType );
        }

        public static void InterfaceIsImplemented<TClass, TInterface>()
            where TClass : class
            where TInterface : class
        {
            Type interfaceType = typeof( TInterface );
            Assert.IsTrue( interfaceType.IsInterface );

            AssertIsAssignableFrom<TClass>( interfaceType );
        }

        private static void AssertIsAssignableFrom<TClass>( Type assignableType ) where TClass : class
        {
            Type classType = typeof( TClass );
            bool isAssignableFrom = assignableType.IsAssignableFrom( classType );
            Assert.IsTrue( isAssignableFrom );
        }
    }
}