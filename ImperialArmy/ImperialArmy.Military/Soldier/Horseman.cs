using System.ComponentModel.Composition;
using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Common.Soldier;

namespace ImperialArmy.Military.Soldier
{
    [Export( typeof( IHorseman ) )]
    [PartCreationPolicy( CreationPolicy.NonShared )]
    internal class Horseman : FootSoldier, IHorseman
    {
        private readonly IHorse _horse;

        public string HorseName
        {
            get { return _horse.Name; }
        }

        [ImportingConstructor]
        public Horseman( IHorse horse )
        {
            _horse = horse;
            Rank = Rank.Horseman;
        }

        public void TrampleFoes()
        {
            _horse.Trample();
        }
    }
}