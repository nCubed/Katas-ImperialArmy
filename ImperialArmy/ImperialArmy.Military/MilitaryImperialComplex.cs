using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using ImperialArmy.Common.Soldier;

namespace ImperialArmy.Military
{
    public static class MilitaryImperialComplex
    {
        static readonly Lazy<CompositionContainer> Container = new Lazy<CompositionContainer>( ComposeContainer );

        public static T CreateSoldier<T>() where T : ISoldier
        {
            Lazy<T> item = Container.Value.GetExport<T>();

            // ReSharper disable once PossibleNullReferenceException
            return item.Value;
        }

        public static IEnumerable<T> CreateManySoldiers<T>( int numberOfSoldiers ) where T : ISoldier
        {
            var soldiers = new List<T>();

            for( int i = 0; i < numberOfSoldiers; i++ )
            {
                T soldier = CreateSoldier<T>();
                soldiers.Add( soldier );
            }

            return soldiers;
        }

        private static CompositionContainer ComposeContainer()
        {
            Assembly exe = Assembly.GetExecutingAssembly();

            var assemblies = new List<Assembly> { exe };

            var referenced = exe.GetReferencedAssemblies()
                .Where( x => x.FullName.StartsWith( "ImperialArmy.", StringComparison.OrdinalIgnoreCase ) );

            assemblies.AddRange( referenced.Select( Assembly.Load ) );

            // finds all objects decorated with the Export attribute.
            // OfType<ComposablePartCatalog> is redundant, but good to clarify code intent.
            // ReSharper disable once RedundantEnumerableCastCall
            var parts = assemblies.Select( x => new AssemblyCatalog( x ) ).OfType<ComposablePartCatalog>();

            var catalog = new AggregateCatalog( parts );

            var container = new CompositionContainer( catalog );

            return container;
        }
    }
}
