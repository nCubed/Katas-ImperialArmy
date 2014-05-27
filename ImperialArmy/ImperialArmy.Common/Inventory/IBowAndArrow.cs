namespace ImperialArmy.Common.Inventory
{
    public interface IBowAndArrow
    {
        int ArrowCount { get; }

        void ShootArrow();
    }
}