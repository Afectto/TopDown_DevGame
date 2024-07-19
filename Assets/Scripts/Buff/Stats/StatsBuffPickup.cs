public class StatsBuffPickup : PickupBuff
{    
    public override void Initialize(IStats stats)
    {
        base.Initialize(stats);
        var currentStats = (BuffStats) stats;
        skin.color = currentStats.Skin.color;
    }
    
    protected override void Invoke()
    {
        EventManager.Instance.OnPickupBuff?.Invoke((BuffStats)Stats);
    }
}