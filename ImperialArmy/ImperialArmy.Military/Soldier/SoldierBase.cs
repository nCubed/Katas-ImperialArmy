using ImperialArmy.Common;
using ImperialArmy.Common.Soldier;

namespace ImperialArmy.Military.Soldier
{
    internal abstract class SoldierBase : ISoldier
    {
        public Rank Rank { get; protected set; }

        public abstract void FightToTheDeath();
    }
}