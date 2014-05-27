using System;
using System.ComponentModel.Composition;
using ImperialArmy.Common;
using ImperialArmy.Common.Soldier;

namespace ImperialArmy.Military.Soldier
{
    [Export( typeof( IFootSoldier ) )]
    [PartCreationPolicy( CreationPolicy.NonShared )]
    internal class FootSoldier : SoldierBase, IFootSoldier
    {
        public FootSoldier()
        {
            Rank = Rank.Soldier;
        }

        public override void FightToTheDeath()
        {
            throw new NotImplementedException();
        }
    }
}
