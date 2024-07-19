using System.Collections;
using UnityEngine;

public class WeaponPickupBuff : MonoBehaviour
{
    private WeaponStats _stats;

    public void Initialize(WeaponStats stats)
    {
        _stats = stats;
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.Instance.OnChangeWeapon?.Invoke(_stats);
            Destroy(gameObject);
        }
    }
}
