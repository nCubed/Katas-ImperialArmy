using ImperialArmy.Common.SoldierOrder;

namespace ImperialArmy.Common.Soldier
{
    public interface IArcher : ISoldier, IShootDistantFoes
    {
        int RemainingArrows { get; }
    }
}
