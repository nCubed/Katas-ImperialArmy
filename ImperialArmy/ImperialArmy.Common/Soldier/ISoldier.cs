using ImperialArmy.Common.SoldierOrder;

namespace ImperialArmy.Common.Soldier
{
    public interface ISoldier : IFightToTheDeath
    {
        Rank Rank { get; }
    }
}
