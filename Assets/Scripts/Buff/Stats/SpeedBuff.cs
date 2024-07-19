public class SpeedBuff : IBuff
{
    private readonly BuffStats _buffStats;

    public SpeedBuff(BuffStats buffStats)
    {
        _buffStats = buffStats;
    }

    public void Apply(Player target)
    {
        target.IncreaseSpeed(_buffStats.Value);
    }

    public void Remove(Player target)
    {
        target.DecreaseSpeed(_buffStats.Value);
    }

    public BuffType GetBuffType()=> _buffStats.Type;

}