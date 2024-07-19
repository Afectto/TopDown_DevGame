public class WeaponPickupBuff : PickupBuff
{
    public override void Initialize(IStats stats)
    {
        base.Initialize(stats);
        var currentStats = (WeaponStats) stats;
        skin.color = currentStats.Skin.color;
    }

    protected override void Invoke()
    {
        EventManager.Instance.OnChangeWeapon?.Invoke((WeaponStats)Stats);
    }
}
