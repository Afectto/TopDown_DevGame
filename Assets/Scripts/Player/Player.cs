using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.OnEnterDeadZone += Dead;
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // ReSharper disable once DelegateSubtraction
        EventManager.Instance.OnEnterDeadZone -= Dead;
    }
}
