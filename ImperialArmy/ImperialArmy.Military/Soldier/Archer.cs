using System.ComponentModel.Composition;
using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Common.Soldier;

namespace ImperialArmy.Military.Soldier
{
    [Export( typeof( IArcher ) )]
    [PartCreationPolicy( CreationPolicy.NonShared )]
    internal class Archer : FootSoldier, IArcher
    {
        private readonly IBowAndArrow _bowAndArrow;

        public int RemainingArrows
        {
            get { return _bowAndArrow.ArrowCount; }
        }

        [ImportingConstructor]
        public Archer( IBowAndArrow bowAndArrow )
        {
            _bowAndArrow = bowAndArrow;
            Rank = Rank.Archer;
        }

        public void ShootDistantFoe()
        {
            _bowAndArrow.ShootArrow();
        }
    }
}