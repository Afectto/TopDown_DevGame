public class DeadVoidZoneBehavior : IVoidZoneBehavior
{
    public void Apply()
    {
        EventManager.Instance.OnEnterDeadZone?.Invoke();
    }

    public void Remove()
    {
        
    }
}