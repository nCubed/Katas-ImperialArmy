using System.ComponentModel.Composition;
using ImperialArmy.Common.Inventory;

namespace ImperialArmy.Military.Inventory
{
    [Export( typeof( IBowAndArrow ) )]
    [PartCreationPolicy( CreationPolicy.NonShared )]
    internal sealed class BowAndArrow : IBowAndArrow
    {
        public int ArrowCount { get; private set; }

        public BowAndArrow()
        {
            ArrowCount = 100;
        }

        public void ShootArrow()
        {
            ArrowCount--;
        }
    }
}