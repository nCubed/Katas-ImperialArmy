using System.ComponentModel.Composition;
using ImperialArmy.Common.Inventory;

namespace ImperialArmy.Military.Inventory
{
    [Export( typeof( IHorse ) )]
    [PartCreationPolicy( CreationPolicy.NonShared )]
    internal class Horse : IHorse
    {
        public string Name { get; set; }

        public void Trample()
        {
            throw new System.NotImplementedException();
        }
    }
}