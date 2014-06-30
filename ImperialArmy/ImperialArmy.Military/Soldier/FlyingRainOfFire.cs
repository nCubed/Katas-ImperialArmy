using System;
using System.ComponentModel.Composition;
using ImperialArmy.Common;
using ImperialArmy.Common.Inventory;
using ImperialArmy.Common.Soldier;

namespace ImperialArmy.Military.Soldier
{
    [Export( typeof( IFlyingRainOfFire ) )]
    [PartCreationPolicy( CreationPolicy.NonShared )]
    internal sealed class FlyingRainOfFire : FootSoldier, IFlyingRainOfFire
    {
        private readonly IBowAndArrow _bowAndArrow;
        private readonly IHorse _horse;

        public int RemainingArrows
        {
            get { return _bowAndArrow.ArrowCount; }
        }

        public string HorseName
        {
            get { return _horse.Name; }
        }

        [ImportingConstructor]
        public FlyingRainOfFire( IBowAndArrow bowAndArrow, IHorse horse )
        {
            _bowAndArrow = bowAndArrow;
            _horse = horse;
            Rank = Rank.FlyingRainOfFire;
        }

        public void LeadTheCharge()
        {
            throw new NotImplementedException();
        }

        public void ShootDistantFoe()
        {
            _bowAndArrow.ShootArrow();
        }

        public void TrampleFoes()
        {
            _horse.Trample();
        }
    }
}
