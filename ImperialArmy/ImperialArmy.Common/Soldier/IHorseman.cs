using ImperialArmy.Common.SoldierOrder;

namespace ImperialArmy.Common.Soldier
{
    public interface IHorseman : ISoldier, ITrampleFoes
    {
        string HorseName { get; }
    }
}
