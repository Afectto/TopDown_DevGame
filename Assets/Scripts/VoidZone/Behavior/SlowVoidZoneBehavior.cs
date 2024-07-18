public class SlowVoidZoneBehavior : IVoidZoneBehavior
{
    private float _speedReductionMultiplayer;
    
    public SlowVoidZoneBehavior(float value)
    {
        _speedReductionMultiplayer = value;
    }
    
    public void Apply()
    {
        EventManager.Instance.OnEnterSlowZone?.Invoke(_speedReductionMultiplayer);
    }

    public void Remove()
    {
        EventManager.Instance.OnExitSlowZone?.Invoke();
    }
}